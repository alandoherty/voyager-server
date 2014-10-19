using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct BRTicket
	{
		#pragma warning disable 0169
		[DataMember]
		public string code;

		[DataMember]
		public string name;

		[DataMember]
		public string longname;

		[DataMember]
		public BRClass tclass;
		#pragma warning restore 0169
	}
}

