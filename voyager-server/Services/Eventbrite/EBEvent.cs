using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBEvent
	{
		#pragma warning disable 0169
		[DataMember]
		public string resource_uri;

		[DataMember]
		public EBText name;

		[DataMember]
		public EBText description;

		[DataMember]
		public EBImage logo;

		[DataMember]
		public string id;

		[DataMember]
		public string url;

		[DataMember]
		public string logo_url;

		[DataMember]
		public EBDateTime start;

		[DataMember]
		public EBDateTime end;

		[DataMember]
		public string created;

		[DataMember]
		public string changed;

		[DataMember]
		public string capacity; // int

		[DataMember]
		public string status;

		[DataMember]
		public string currency;

		[DataMember]
		public string online_event;

		[DataMember]
		public string organizer_id;

		[DataMember]
		public string venue_id;

		[DataMember]
		public string category_id; // int

		[DataMember]
		public string subcategory_id; // int

		[DataMember]
		public string format_id; // int

		[DataMember]
		public EBOrganizer organizer;

		[DataMember]
		public EBVenue venue;

		[DataMember]
		public EBCategory category;

		[DataMember]
		public EBCategory subcategory;

		[DataMember]
		public EBFormat format;

		[DataMember]
		public EBTicketClass[] ticket_classes;
		#pragma warning restore 0169
	}
}

