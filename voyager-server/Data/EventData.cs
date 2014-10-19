using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class EventData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public string Name;

		[DataMember]
		public string Organizer;

		[DataMember]
		public string Image;

		[DataMember]
		public string Date;

		[DataMember]
		public LocationData Location;

		[DataMember]
		public string LocationString;

		[DataMember]
		public ContactData Contact;
		#endregion
		#pragma warning restore 0169
	}
}

