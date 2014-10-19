using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct BRFareData
	{
		#pragma warning disable 0169
		[DataMember]
		public bool travelcard_orig;

		[DataMember]
		public bool travelcard_dest;

		[DataMember]
		public bool zonal_orig;

		[DataMember]
		public bool zonal_dest;

		[DataMember]
		public int validity;

		[DataMember]
		public float discount_price;

		[DataMember]
		public BRFare[] fares;
		#pragma warning restore 0169
	}
}

