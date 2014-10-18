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

			res.Write ("\"[\\n{\\n\\\"name\\\" : \\\"The Fadathon\\\",\\n\\\"description\\\" : \\\"We sell fad things here\\\",\\n\\\"image\\\" : \\\"http://jamiehoyle.com/img.png\\\",\\n\\\"rating\\\" : 5\\n},\\n{\\n\\\"name\\\" : \\\"The Conferencethon\\\",\\n\\\"description\\\" : \\\"We do conferences\\\",\\n\\\"image\\\" : \\\"http://jamiehoyle.com/img2.png\\\",\\n\\\"rating\\\" : 4\\n},\\n{\\n\\\"name\\\" : \\\"The Jamieathon\\\",\\n\\\"description\\\" : \\\"We do anjuli\\\",\\n\\\"image\\\" : \\\"http://jamiehoyle.com/img3.png\\\",\\n\\\"rating\\\" : 1\\n}\\n]\"");
			
			// send response
			res.Send ();
		}
		#endregion
	}
}

