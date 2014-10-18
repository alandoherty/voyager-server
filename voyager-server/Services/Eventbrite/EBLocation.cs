using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBLocation
	{
		#pragma warning disable 0169
		[DataMember]
		string address_1;

		[DataMember]
		string address_2;

		[DataMember]
		string city;

		[DataMember]
		string region;

		[DataMember]
		string postal_code;

		[DataMember]
		string country;

		[DataMember]
		double latitude;

		[DataMember]
		double longitude;
		#pragma warning restore 0169
	}
}

