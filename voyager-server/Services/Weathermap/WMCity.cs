using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMCity
	{
		[DataMember]
		public long id;

		[DataMember]
		public string name;

		[DataMember]
		public string country;

		[DataMember]
		public long population;
	}
}

