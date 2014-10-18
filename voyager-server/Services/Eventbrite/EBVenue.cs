using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBVenue
	{
		#pragma warning disable 0169
		[DataMember]
		EBLocation location;

		[DataMember]
		string resource_uri;

		[DataMember]
		long id;

		[DataMember]
		string name;
		#pragma warning restore 0169
	}
}

