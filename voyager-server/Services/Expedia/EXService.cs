using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using voyagerlib;
using System.Threading.Tasks;

namespace voyagerserver
{
	public static class EXService
	{
		#region Constants
		public const string API = "http://api.ean.com/ean-services/rs/";
		public const string APIKey = "265ppn2ehhz6h95u55adej76";
		public const string APISecret = "7dnpcM6Y";
		#endregion

		#region Methods
		public static EXSearchData Search(string arrivalDate, string depatureDate, string city) {
			// serializer
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(TRNearbyData));

			// data
			string str = null;

			// build query
			string uri = API + "hotel/v3/list?&arrivalDate=" + arrivalDate + "&depatureDate=" + depatureDate + "&numberOfResults=3";

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

			return new EXSearchData ();
		}
		#endregion
	}
}

