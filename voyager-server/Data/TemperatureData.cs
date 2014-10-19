using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class TemperatureData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public float Day;

		[DataMember]
		public float Minimum;

		[DataMember]
		public float Maximum;

		[DataMember]
		public float Midnight;

		[DataMember]
		public float Evening;

		[DataMember]
		public float Morning;
		#endregion
		#pragma warning restore 0169
	}
}

