using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBImage
	{
		#pragma warning disable 0169
		[DataMember]
		public int id;

		[DataMember]
		public string url;
		#pragma warning restore 0169
	}
}

