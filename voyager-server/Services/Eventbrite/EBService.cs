using System;
using voyagerlib;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

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

			System.Net.WebClient webclient = new System.Net.WebClient ();

			string str = null;
			try {
				str = webclient.DownloadString ("https://www.eventbriteapi.com/v3/events/search/?token=HYNJ37UW2IAHOF27XLSL?q=" + Utilities.UrlEncode(query));
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

