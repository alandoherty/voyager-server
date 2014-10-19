using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct BRFare
	{
		#pragma warning disable 0169
		[DataMember]
		public BRFareSetter fare_setter;

		[DataMember]
		public BRTicket ticket;

		[DataMember]
		public BRPrice adult;

		[DataMember]
		public BRPrice child;
		#pragma warning restore 0169
	}
}

