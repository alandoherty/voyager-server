using System;
using System.Collections.Generic;

namespace voyagerlib
{
	public class Session
	{
		#region Fields
		private string _id;
		private Dictionary<string, object> _data = new Dictionary<string, object> ();
		#endregion

		#region Properties
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Id {
			get {
				return _id;
			}
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public Dictionary<string, object> Data {
			get {
				return _data;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.Session"/> class with a unique id.
		/// </summary>
		public Session ()
		{
			_id = Guid.NewGuid ().ToString();
		}
		#endregion
	}
}

