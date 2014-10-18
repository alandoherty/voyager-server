using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBSearchData
	{
		#pragma warning disable 0169
		[DataMember]
		public COPagination pagination;

		[DataMember]
		public EBEvent[] events;
		#pragma warning restore 0169
	}
}

