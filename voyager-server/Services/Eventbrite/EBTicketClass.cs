using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBTicketClass
	{
		#pragma warning disable 0169
		[DataMember]
		public string resource_uri;

		[DataMember]
		public string id;

		[DataMember]
		public string name;

		[DataMember]
		public string description;

		[DataMember]
		public bool donation;

		[DataMember]
		public bool free;

		[DataMember]
		public string minimum_quantity;

		[DataMember]
		public string maximum_quantity;

		[DataMember]
		public long event_id;
		#pragma warning restore 0169
	}
}

