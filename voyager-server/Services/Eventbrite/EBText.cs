using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBText
	{
		#pragma warning disable 0169
		[DataMember]
		public string text;

		[DataMember]
		public string html;
		#pragma warning restore 0169
	}
}

