using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMCity
	{
		#pragma warning disable 0169
		[DataMember]
		public long id;

		[DataMember]
		public string name;

		[DataMember]
		public string country;

		[DataMember]
		public long population;
		#pragma warning restore 0169
	}
}

