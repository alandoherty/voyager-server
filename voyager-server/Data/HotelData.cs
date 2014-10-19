using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class HotelData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public string Name;

		[DataMember]
		public string Type;

		[DataMember]
		public bool Flexible;

		[DataMember]
		public string Telephone;

		[DataMember]
		public string Email;

		[DataMember]
		public string Image;

		[DataMember]
		public float CostPerNight;
		#endregion
		#pragma warning restore 0169
	}
}

