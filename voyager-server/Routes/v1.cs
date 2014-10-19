﻿using System;
using voyagerlib;
using voyagerlib.http;
using System.Collections.Generic;

namespace voyagerserver.routes
{
	public static class v1
	{
		#region Methods
		/// <summary>
		/// Search for hackathons
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/events/search")]
		public static void SearchEvents(Request req, Response res) {
			// check exists
			if (!req.Parameters.ContainsKey ("searchText")) {
				Utilities.Error ("Invalid search request, missing parameter to search (searchText)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			string searchText = req.Parameters ["searchText"];

			// search for data
			EBSearchData searchData = EBService.Search (searchText);
			List<EventData> data = new List<EventData>();

			// respond
			foreach (EBEvent eventData in searchData.events) {
				data.Add(new EventData() {
					Name = eventData.name.text,
					Organizer = eventData.organizer.name,
					Image = eventData.logo.url,
					Date = eventData.start.utc,
					Location = new LocationData() {
						Latitude = eventData.venue.location.latitude,
						Longitude = eventData.venue.location.longitude,
						City = eventData.venue.location.city,
						Country = eventData.venue.location.country
					},
					LocationString = eventData.venue.location.city + ", " + eventData.venue.location.country
				});
			}

			// write
			res.Write (data.ToArray ());

			// send response
			res.Send ();
		}

		/// <summary>
		/// Get the weather for a longitude and latitude.
		/// </summary>
		/// <param name="req">Req.</param>
		/// <param name="res">Res.</param>
		[Route(HttpMethod.GET, "/v1/weather/get")]
		public static void GetWeather(Request req, Response res) {
			// check exists
			if (!req.Parameters.ContainsKey ("lon") || !req.Parameters.ContainsKey ("lat")) {
				Utilities.Error ("Invalid weather request, missing parameter to lookup (lon/lat)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			float longitude = float.Parse(req.Parameters ["lon"]);
			float latitude = float.Parse (req.Parameters ["lat"]);

			// search for data
			WMWeatherData weatherData = WMService.Weather (longitude, latitude);
			List<ForecastData> data = new List<ForecastData>();

			// day
			byte day = 1;

			// respond
			foreach (WMReport reportData in weatherData.list) {
				data.Add(new ForecastData() {
					Day = day,
					Temperature = new TemperatureData() {
						Day = reportData.temp.day,
						Midnight = reportData.temp.night,
						Evening = reportData.temp.eve,
						Morning = reportData.temp.morn,
						Minimum = reportData.temp.min,
						Maximum = reportData.temp.max
					},
					WeatherString = reportData.weather[0].main,
					WeatherDescription = reportData.weather[0].description
				});

				// increment day
				day++;
			}

			// write
			res.Write (data.ToArray ());

			// send response
			res.Send ();
		}

		/// <summary>
		/// Finds nearby stations.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/trains/nearest")]
		public static void NearestStations(Request req, Response res) {
			// check exists
			if (!req.Parameters.ContainsKey ("lon") || !req.Parameters.ContainsKey ("lat")) {
				Utilities.Error ("Invalid weather request, missing parameter to lookup (lon/lat)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			float longitude = float.Parse(req.Parameters ["lon"]);
			float latitude = float.Parse (req.Parameters ["lat"]);

			// search for data
			TRNearbyData nearbyData = TRService.Nearby (longitude, latitude);

			if (nearbyData.stations.Length == 0) {
				// no results
				res.Write (new EmptyData());
			} else {
				// first result
				TRStation stationData = nearbyData.stations [0];

				res.Write (new StationData() {
					StationCode = stationData.station_code,
					Name = stationData.name,
					Mode = stationData.mode,
					Distance = stationData.distance
				});
			}

			// send response
			res.Send ();
		}
		#endregion
	}
}

