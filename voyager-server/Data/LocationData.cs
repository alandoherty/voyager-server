using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class LocationData : EmptyData
	{
		#pragma warning disable 0169
		[DataMember]
		public float Latitude;

		[DataMember]
		public float Longitude;

		[DataMember]
		public string City;

		[DataMember]
		public string Country;
		#pragma warning restore 0169
	}
}

