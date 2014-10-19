using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class BRPrice
	{
		#pragma warning disable 0169
		[DataMember]
		public BRPriceStatus status;

		[DataMember]
		public int fare;
		#pragma warning restore 0169
	}
}

