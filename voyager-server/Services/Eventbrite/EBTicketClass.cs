using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBTicketClass
	{
		#pragma warning disable 0169
		[DataMember]
		string resource_uri;

		[DataMember]
		long id;

		[DataMember]
		string name;

		[DataMember]
		string description;

		[DataMember]
		bool donation;

		[DataMember]
		bool free;

		[DataMember]
		int minimum_quantity;

		[DataMember]
		int maximum_quantity;

		[DataMember]
		long event_id;
		#pragma warning restore 0169
	}
}

