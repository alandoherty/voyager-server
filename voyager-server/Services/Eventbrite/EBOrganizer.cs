using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBOrganizer
	{
		#pragma warning disable 0169
		[DataMember]
		public EBText description;

		[DataMember]
		public EBImage logo;

		[DataMember]
		public string resource_uri;

		[DataMember]
		public string id;

		[DataMember]
		public string name;

		[DataMember]
		public string url;

		[DataMember]
		public string num_past_events;

		[DataMember]
		public string num_future_events;
		#pragma warning restore 0169	
	}
}

