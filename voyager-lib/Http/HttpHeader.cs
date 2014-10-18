using System;

namespace voyagerlib.http
{
	public class HttpHeader
	{
		#region Fields
		private string _name = "";
		private string _value = "";
		#endregion

		#region Properties
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get {
				return _name;
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public string Value {
			get {
				return _value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.HttpHeader"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		public HttpHeader (string name, string value)
		{
			_name = name;
			_value = value;
		}
		#endregion
	}
}

