using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct TRNearbyData
	{
		#pragma warning disable 0169
		[DataMember]
		public float minlon;

		[DataMember]
		public float minlat;

		[DataMember]
		public float maxlon;

		[DataMember]
		public float maxlat;

		[DataMember]
		public float searchlon;

		[DataMember]
		public float searchlat;

		[DataMember]
		public int page;

		[DataMember]
		public int rpp;

		[DataMember]
		public int total;

		[DataMember]
		public TRStation[] stations;
		#pragma warning restore 0169
	}
}

