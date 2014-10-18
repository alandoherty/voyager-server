using System;
using voyagerlib;
using System.Reflection;

namespace voyagerserver
{
	public static class Voyager
	{

		#region Methods
		public static void Main (string[] args)
		{
			// create server
			Server server = new Server (Assembly.GetExecutingAssembly(), 8080);

			// start server
			server.Start ();
		}
		#endregion
	}
}
