using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct COPagination
	{
		[DataMember]
		public int object_count;

		[DataMember]
		public int page_number;

		[DataMember]
		public int page_size;

		[DataMember]
		public int page_count;
	}
}

