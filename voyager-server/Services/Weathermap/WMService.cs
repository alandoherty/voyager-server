using System;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using voyagerlib;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace voyagerserver
{
	public static class WMService
	{
		#region Constants 
		public const string API = "http://api.openweathermap.org/data/2.5/";
		#endregion

		#region Methods
		/// <summary>
		/// Lookup the weather at the specified longitude and latitude.
		/// </summary>
		/// <param name="longitude">Longitude.</param>
		/// <param name="latitude">Latitude.</param>
		public static WMWeatherData Weather(float longitude, float latitude) {
			// serializer
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(WMWeatherData));

			// data
			string str = null;

			// build query
			string uri = API + "forecast/daily/?mode=json&cnt=10&units=metric&lat=" + latitude + "&lon=" + longitude;

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
			} catch (Exception ex) {
				// error
				Utilities.Error (ex.InnerException.Message + "\n" + ex.InnerException.StackTrace);
			}

			// memory stream
			using (MemoryStream ms = new MemoryStream()) {
				// write string
				byte[] json = Encoding.ASCII.GetBytes (str);
				ms.Write (json, 0, json.Length);
				ms.Flush ();

				// decode
				ms.Seek (0, SeekOrigin.Begin);

				return (WMWeatherData)serializer.ReadObject (ms);
			}
		}
		#endregion
	}
}

