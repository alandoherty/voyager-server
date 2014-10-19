using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class ContactData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public string Email;

		[DataMember]
		public string PhoneNumber;

		[DataMember]
		public string TwitterHandle;

		[DataMember]
		public string FacebookHandle;
		#endregion
		#pragma warning restore 0169
	}
}

