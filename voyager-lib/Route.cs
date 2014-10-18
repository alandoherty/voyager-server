using System;

namespace voyagerlib
{
	public class Route : Attribute
	{
		#region Fields
		private HttpMethod _method;
		private string _path;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the method.
		/// </summary>
		/// <value>The method.</value>
		public HttpMethod Method {
			get {
				return _method;
			}
		}
		#endregion
	}
}

