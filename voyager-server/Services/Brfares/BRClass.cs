using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct BRClass
	{
		#pragma warning disable 0169
		[DataMember]
		public int code;

		[DataMember]
		public string desc;
	}
}

