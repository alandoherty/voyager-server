using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMReport
	{
		[DataMember]
		public long dt;

		[DataMember]
		public WMTemperature temp;

		[DataMember]
		public float pressure;

		[DataMember]
		public float humidity;

		[DataMember]
		public WMClimate[] weather;

		[DataMember]
		public float speed;

		[DataMember]
		public float deg;

		[DataMember]
		public float clouds;
	}
}

