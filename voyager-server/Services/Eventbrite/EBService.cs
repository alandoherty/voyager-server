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
	public class EBService
	{
		#region Constants
		public const string Token = "HYNJ37UW2IAHOF27XLSL";
		#endregion

		#region Methods
		public static void Search(string query) {
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(EBSearchData));

			string str = null;
			try {
				HttpClient client = new HttpClient ();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", "HYNJ37UW2IAHOF27XLSL");
				Task<string> task = client.GetStringAsync ("https://www.eventbriteapi.com/v3/events/search/?token=?q=" + Utilities.UrlEncode (query));

				task.Wait ();
				str = task.Result;
			}
			catch(Exception ex) {
				Utilities.Error (ex.Message + "\n" + ex.StackTrace);
			}

			using (MemoryStream ms = new MemoryStream()) {
				// write string
				byte[] json = Encoding.UTF8.GetBytes (str);
				ms.Write (json, 0, json.Length);
				ms.Flush ();

				// decode
				EBSearchData searchData = (EBSearchData)serializer.ReadObject (ms);
			}
		}
		#endregion
	}
}

