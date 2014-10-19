using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class BRFareSetter
	{
		#pragma warning disable 0169
		[DataMember]
		public string code;

		[DataMember]
		public string name;
		#pragma warning restore 0169
	}
}

