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
			}

			// parameters
			string searchText = req.Parameters ["searchText"];

			// search te
			Console.WriteLine ("Jamie just searched for " + searchText);

			// send response
			res.Send ();
		}
		#endregion
	}
}

