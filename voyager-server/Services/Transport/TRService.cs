using System;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using voyagerlib;
using System.IO;
using System.Text;

namespace voyagerserver
{
	public static class TRService
	{
		#region Constants 
		public const string API = "http://transportapi.com/v3/uk/train/stations/";
		public const string APIKey = "d82762b6321a6c4fb36b8295df381488";
		public const string APIId = "3e0f85ac";
		#endregion

		#region Methods
		/// <summary>
		/// Find train stations nearby a longitude and latitude.
		/// </summary>
		/// <param name="lon">Longitude.</param>
		/// <param name="lat">Latitude.</param>
		public static TRNearbyData Nearby(float longitude, float latitude) {
			// serializer
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(TRNearbyData));

			// data
			string str = null;

			// build query
			string uri = API + "near.json?&api_key=" + APIKey + "&app_id=" + APIId + "&rpp=5&lat=" + latitude + "&lon=" + longitude;

			// download data
			try {
				// authentication
				HttpClient client = new HttpClient ();

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

				return (TRNearbyData)serializer.ReadObject (ms);
			}
		}
		#endregion
	}
}

