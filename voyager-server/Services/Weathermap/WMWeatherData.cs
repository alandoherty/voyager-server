using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMWeatherData
	{
		#pragma warning disable 0169
		[DataMember]
		public int cod;

		[DataMember]
		public string message;

		[DataMember]
		public WMCity city;

		[DataMember]
		public int cnt;

		[DataMember]
		public WMReport[] list;
		#pragma warning restore 0169
	}
}

