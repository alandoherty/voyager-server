using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMClimate
	{
		[DataMember]
		public int id;

		[DataMember]
		public string main;

		[DataMember]
		public string description;

		[DataMember]
		public string icon;
	}
}

