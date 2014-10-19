﻿using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class LocationData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public float Latitude;

		[DataMember]
		public float Longitude;

		[DataMember]
		public string City;

		[DataMember]
		public string PostalCode;

		[DataMember]
		public string Address;

		[DataMember]
		public string Country;
		#endregion
		#pragma warning restore 0169
	}
}

