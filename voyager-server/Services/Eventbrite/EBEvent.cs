using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBEvent
	{
		#pragma warning disable 0169
		[DataMember]
		string resource_uri;

		[DataMember]
		EBText name;

		[DataMember]
		EBText description;

		[DataMember]
		EBImage logo;

		[DataMember]
		long id;

		[DataMember]
		string url;

		[DataMember]
		string logo_url;

		[DataMember]
		EBDateTime start;

		[DataMember]
		EBDateTime end;

		[DataMember]
		string created;

		[DataMember]
		string changed;

		[DataMember]
		int capacity;

		[DataMember]
		string status;

		[DataMember]
		string currency;

		[DataMember]
		string online_event;

		[DataMember]
		long organizer_id;

		[DataMember]
		string venue_id;

		[DataMember]
		int category_id;

		[DataMember]
		int subcategory_id;

		[DataMember]
		int format_id;

		[DataMember]
		EBOrganizer organizer;

		[DataMember]
		EBVenue venue;

		[DataMember]
		EBCategory category;

		[DataMember]
		EBCategory subcategory;

		[DataMember]
		EBFormat format;

		[DataMember]
		EBTicketClass[] ticket_classes;
		#pragma warning restore 0169
	}
}

