﻿using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public struct WMClimate
	{
		#pragma warning disable 0169
		[DataMember]
		public int id;

		[DataMember]
		public string main;

		[DataMember]
		public string description;

		[DataMember]
		public string icon;
		#pragma warning restore 0169
	}
}

