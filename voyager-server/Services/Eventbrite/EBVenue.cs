using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBVenue
	{
		#pragma warning disable 0169
		[DataMember]
		public EBLocation location;

		[DataMember]
		public string resource_uri;

		[DataMember]
		public string id;

		[DataMember]
		public string name;
		#pragma warning restore 0169
	}
}

