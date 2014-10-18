using System;
using voyagerlib.http;
using System.Reflection;

namespace voyagerlib
{
	public class Route : Attribute
	{
		#region Fields
		private HttpMethod _method;
		private string _path = "";
		private MethodInfo _function = null;
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

		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path {
			get {
				return _path;
			}
		}

		/// <summary>
		/// Gets the function.
		/// </summary>
		/// <value>The function.</value>
		public MethodInfo Function {
			get {
				return _function;
			} set {
				_function = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Attribute a route with the specified method and path.
		/// </summary>
		/// <param name="method">Method.</param>
		/// <param name="path">Path.</param>
		public Route(HttpMethod method, string path) {
			_method = method;
			_path = path;
		}
		#endregion
	}
}

