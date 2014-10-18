using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMTemperature
	{
		[DataMember]
		public float day;

		[DataMember]
		public float min;

		[DataMember]
		public float max;

		[DataMember]
		public float night;

		[DataMember]
		public float eve;

		[DataMember]
		public float morn;
	}

}

