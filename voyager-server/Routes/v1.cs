using System;
using voyagerlib;
using voyagerlib.http;

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
		[Route(HttpMethod.GET, "/v1/search")]
		public static void Search(Request req, Response res) {
			// check exists
			if (!req.Parameters.ContainsKey ("searchText")) {
				Utilities.Error ("Invalid request, missing parameter to search");
				res.Send (HttpStatusCode.BadRequest);
				return;
			}

			// parameters
			string searchText = req.Parameters ["searchText"];

			res.Write (new HackathonData[] {
				new HackathonData() {
					Name = "Jamie's Codeathon",
					Organizer = "Jamie Hoyle",
					Image = "http://jamiehoyle.com/img.png",
					Date = DateTime.Now.ToString(),
					/*Location = new LocationData() {
						Longitude = 0.5f,
						Latitude = 0.5f
					}*/
					Location = "Manchester, Central"
				}
			});

			EBService.Search (searchText);

			// send response
			res.Send ();
		}
		#endregion
	}
}

