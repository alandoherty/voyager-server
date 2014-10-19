using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class LocationData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public float Latitude;

		[DataMember]
		public float Longitude;

		[DataMember]
		public string City;

		[DataMember]
		public string PostalCode;

		[DataMember]
		public string Address;

		[DataMember]
		public string Country;

		/// <summary>
		/// Jamie wanted this because he is a lazy arse pleb who can't concat like 3 strings. I know, serioisly. It's like he doesn't evne know how 2  java and not cry ever time.
		/// </summary>
		[DataMember]
		public string AddressString;
		#endregion
		#pragma warning restore 0169
	}
}

