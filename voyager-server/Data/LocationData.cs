﻿using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct LocationData
	{
		[DataMember]
		public float Latitude;

		[DataMember]
		public float Longitude;
	}
}

