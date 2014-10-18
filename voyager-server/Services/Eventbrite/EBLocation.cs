using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBLocation
	{
		#pragma warning disable 0169
		[DataMember]
		public string address_1;

		[DataMember]
		public string address_2;

		[DataMember]
		public string city;

		[DataMember]
		public string region;

		[DataMember]
		public string postal_code;

		[DataMember]
		public string country;

		[DataMember]
		public float latitude;

		[DataMember]
		public float longitude;
		#pragma warning restore 0169
	}
}

