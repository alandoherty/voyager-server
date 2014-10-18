using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMWeatherData
	{
		[DataMember]
		public int cod;

		[DataMember]
		public float message;

		[DataMember]
		public WMCity city;

		[DataMember]
		public int cnt;

		[DataMember]
		public WMReport[] list;
	}
}

