using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBFormat
	{
		#pragma warning disable 0169
		[DataMember]
		public string resource_uri;

		[DataMember]
		public string id; // int

		[DataMember]
		public string name;

		[DataMember]
		public string short_name;
		#pragma warning restore 0169
	}
}

