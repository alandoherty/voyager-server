using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct TRStation
	{
		#pragma warning disable 0169
		[DataMember]
		public string station_code;

		[DataMember]
		public string atcocode;

		[DataMember]
		public string tiploc_code;

		[DataMember]
		public string name;

		[DataMember]
		public string mode;

		[DataMember]
		public long distance;

		[DataMember]
		public float longitude;

		[DataMemberAttribute]
		public float latitude;
		#pragma warning restore 0169
	}
}

