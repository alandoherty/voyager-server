using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBOrganizer
	{
		#pragma warning disable 0169
		[DataMember]
		EBText description;

		[DataMember]
		EBImage logo;

		[DataMember]
		string resource_uri;

		[DataMember]
		long id;

		[DataMember]
		string name;

		[DataMember]
		string url;

		[DataMember]
		int num_past_events;

		[DataMember]
		int num_future_events;
		#pragma warning restore 0169	
	}
}

