using System;
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
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/events/search");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

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
						PostalCode = eventData.venue.location.postal_code,
						Address = eventData.venue.location.address_1,
						City = eventData.venue.location.city,
						Country = eventData.venue.location.country,
						AddressString = eventData.venue.location.address_1 + "\n" + eventData.venue.location.postal_code + "\n" + eventData.venue.location.city
					},
					LocationString = eventData.venue.location.city + ", " + eventData.venue.location.country,
					Contact = new ContactData() {

					}
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
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/weather/get");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

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
		/// Finds the nearest hotel.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/hotels/nearest")]
		public static void NearestHotel(Request req, Response res) {
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/hotels/nearest");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

			// check exists
			if (!req.Parameters.ContainsKey ("lon") || !req.Parameters.ContainsKey ("lat")) {
				Utilities.Error ("Invalid hotel request, missing parameter to lookup (lon/lat)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			res.Write (new HotelData() {
				Name = "London Central Tower Bridge Hotel",
				Type = "Double Room",
				Flexible = true,
				Telephone = "0871 984 6388",
				Email = "",
				Image = "http://www.travelodge.co.uk/sites/default/files/styles/hotel_hero_large/public/Tower-Bridge-Exterior_MG_5523.jpg?itok=-FJ-uj02",
				CostPerNight = 72
			});	

			// send response
			res.Send ();
		}

		/// <summary>
		/// Finds nearest stations.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/trains/nearest")]
		public static void NearestStations(Request req, Response res) {
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/trains/nearest");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

			// check exists
			if (!req.Parameters.ContainsKey ("lon") || !req.Parameters.ContainsKey ("lat")) {
				Utilities.Error ("Invalid weather request, missing parameter to lookup (lon/lat)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			//float longitude = float.Parse(req.Parameters ["lon"]);
			//float latitude = float.Parse (req.Parameters ["lat"]);

			float longitude = -2.2300f;
			float latitude = 53.4770f;

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
					Longitude = stationData.longitude,
					Latitude = stationData.latitude,
					//Distance = stationData.distance
					Distance = 33243
				});
			}

			// send response
			res.Send ();
		}

		/// <summary>
		/// Finds nearby stations.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/trains/nearby")]
		public static void NearbyStations(Request req, Response res) {
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/trains/nearby");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

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
			List<StationData> data = new List<StationData>();

			// respond
			foreach (TRStation stationData in nearbyData.stations) {
				data.Add(new StationData() {
					StationCode = stationData.station_code,
					Name = stationData.name,
					Mode = stationData.mode,
					Distance = stationData.distance
				});
			}

			// write
			res.Write (data.ToArray ());

			// send response
			res.Send ();
		}

		/// <summary>
		/// Finds fares for train routes.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/trains/fares")]
		public static void Fares(Request req, Response res) {
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/trains/nearby");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

			// check exists
			if (!req.Parameters.ContainsKey ("from") || !req.Parameters.ContainsKey ("to")) {
				Utilities.Error ("Invalid fare request, missing parameter to lookup (from/to)");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			string from = req.Parameters ["from"];
			string to = req.Parameters ["to"];

			// search for data
			BRFareData faresData = BRService.Fares (from, to);

			BRFare[] fares = new BRFare[faresData.fares.Length];
			faresData.fares.CopyTo (fares, 0);
			Array.Reverse (fares);

			// respond
			foreach (BRFare fareData in fares) {
				// build fare
				FareData fare = new FareData () {
					Class = fareData.ticket.tclass.desc,
					//ChildCost = (fareData.child != null) ? (fareData.child.fare / 100) : 0,
					//AdultCost = (fareData.adult != null) ? (fareData.adult.fare / 100) : 0,
					ChildCost = 31.4f,
					AdultCost = 62.8f
				};

				// cheapest 1st class
				if (fare.ChildCost != 0 && fare.AdultCost != 0 && fare.Class == "1ST") {
					// write
					res.Write (fare);
					
					// return
					break;
				}
			}

			// send response
			res.Send ();
		}

		/// <summary>
		/// Ping back to check if session is valid.
		/// </summary>
		/// <param name="req">Request.</param>
		/// <param name="res">Response.</param>
		[Route(HttpMethod.GET, "/v1/ping")]
		public static void Ping(Request req, Response res) {
			// authorization
			if (!req.Authorized) {
				Utilities.Error ("Invalid authentication, denied /v1/ping");
				res.Send (HttpStatusCode.Unauthorized);
				return;
			}

			// write some data
			res.Write ("{\"session\": \"" + req.Session.Id + "\", \"dataCount\": \"" + req.Session.Data.Count.ToString() + "\"}");

			// send
			res.Send ();
		}
		#endregion
	}
}

