using System;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;
using voyagerlib;
using System.IO;
using System.Text;

namespace voyagerserver
{
	public static class BRService
	{
		#region Constants
		public const string API = "http://api.brfares.com/";
		#endregion

		#region Methods
		/// <summary>
		/// Find fares based on an origin and destination
		/// </summary>
		/// <param name="origin">Origin.</param>
		/// <param name="destination">Destination.</param>
		public static BRFareData Fares(string origin, string destination) {
			// serializer
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(BRFareData));

			// data
			string str = null;

			// build query
			string uri = API + "querysimple?orig=" + origin + "&dest=" + destination;

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

				return (BRFareData)serializer.ReadObject (ms);
			}
		}
		#endregion
	}
}

