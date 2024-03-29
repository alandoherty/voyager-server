﻿
using System;
using voyagerlib;
using System.Reflection;
using System.IO;

namespace voyagerserver
{
	public static class Voyager
	{
		#region Constants
		public const string CacheFile = "cache.dat";
		#endregion

		#region Fields
		public static Cache Cache;
		#endregion

		#region Methods
		public static void SaveCache() {
			Cache.Save (CacheFile);
		}

		public static void Main (string[] args)
		{
			// check exists
			bool cacheExists = File.Exists (CacheFile);

			// load cache
			Cache = new Cache (CacheFile);

			// rawtenstall
			// lon = 2.2910
			// lat = -53.6990

			// announce
			if (cacheExists)
				Utilities.Info("Opened cache file with " + Cache.Count + " stored keywords");
			else
				Utilities.Info("Created cache file with 0 stored keywords");

			// create server
			Server server = new Server (Assembly.GetExecutingAssembly(), 8080);

			// start server
			server.Start ();
		}
		#endregion
	}
}
