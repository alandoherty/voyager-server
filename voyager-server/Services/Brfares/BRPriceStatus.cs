using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct BRPriceStatus
	{
		#pragma warning disable 0169
		[DataMember]
		public string code;

		[DataMember]
		public string name;

		[DataMember]
		public string ticket_code;
		#pragma warning restore 0169
	}
}

