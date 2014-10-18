using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct EBCategory
	{
		#pragma warning disable 0169
		[DataMember]
		string resource_uri;

		[DataMember]
		int id;

		[DataMember]
		string name;

		[DataMember]
		string name_localized;

		[DataMember]
		string short_name;
		#pragma warning restore 0169
	}
}

