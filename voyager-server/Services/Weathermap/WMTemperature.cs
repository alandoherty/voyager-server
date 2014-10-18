using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMTemperature
	{
		#pragma warning disable 0169
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
		#pragma warning restore 0169
	}

}

