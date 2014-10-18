using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EventData
	{
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
		#endregion
	}
}

