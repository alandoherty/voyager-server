using System;
using voyagerlib;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace voyagerserver
{
	public static class EBService
	{
		#region Constants
		public const string Token = "HYNJ37UW2IAHOF27XLSL";
		public const string API = "https://www.eventbriteapi.com/v3/";
		#endregion

		#region Methods
		/// <summary>
		/// Search for events.
		/// </summary>
		/// <param name="query">Query.</param>
		public static EBSearchData Search(string query) {
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(EBSearchData));

			// cache
			string str = null;

			// check cache
			if (Voyager.Cache.Exists (query)) {
				// retrieve from cache
				str = Voyager.Cache.Get (query);

				// announce
				Utilities.Info("Retrieved search query " + query + " (from cache)");
			}

			if (str == null) {
				// build query
				string uri = API + "events/search/?popular=true&q=" + Utilities.UrlEncode (query);
		
				// download data

				try {
					// authentication
					HttpClient client = new HttpClient ();
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", "HYNJ37UW2IAHOF27XLSL");

					// get string
					Task<string> task = client.GetStringAsync (uri);

					// wait and get result
					task.Wait ();
					str = task.Result;

					// store in cache
					Voyager.Cache.Set(query, str);
					Voyager.SaveCache();

					// announce
					Utilities.Info("Stored query " + query + " in cache");
				} catch (Exception ex) {
					// error
					Utilities.Error (ex.InnerException.Message + "\n" + ex.InnerException.StackTrace);
				}
			}

			// memory stream
			using (MemoryStream ms = new MemoryStream()) {
				// write string
				byte[] json = Encoding.ASCII.GetBytes (str);
				ms.Write (json, 0, json.Length);
				ms.Flush ();

				// decode
				ms.Seek (0, SeekOrigin.Begin);

				return (EBSearchData)serializer.ReadObject (ms);
			}
		}
		#endregion
	}
}

