using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBDateTime
	{
		#pragma warning disable 0169
		[DataMember]
		public string timezone;

		[DataMember]
		public string local;

		[DataMember]
		public string utc;
		#pragma warning restore 0169
	}
}

