using System;
using voyagerlib.http;

namespace voyagerserver
{
	public static class Voyager
	{
		#region Methods
		public static void Main (string[] args)
		{
			HttpServer server = new HttpServer (8080);
			server.Start ();
		}
		#endregion
	}
}
