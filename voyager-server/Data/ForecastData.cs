using System;
using System.Runtime.Serialization;

namespace voyagerserver
{
	public class ForecastData : EmptyData
	{
		#pragma warning disable 0169
		#region Fields
		[DataMember]
		public byte Day;

		[DataMember]
		public TemperatureData Temperature;

		[DataMember]
		public string WeatherString;

		[DataMember]
		public string WeatherDescription;
		#endregion
		#pragma warning restore 0169
	}
}

