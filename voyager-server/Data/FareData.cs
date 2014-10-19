using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class FareData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public float AdultCost;

		[DataMember]
		public float ChildCost;

		[DataMember]
		public string Class;
		#endregion
		#pragma warning restore 0169
	}
}

