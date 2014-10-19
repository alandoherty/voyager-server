using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class StationData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public string StationCode;

		[DataMember]
		public string Name;

		[DataMember]
		public string Mode;

		[DataMember]
		public long Distance;
		#endregion
		#pragma warning restore 0169
	}
}

