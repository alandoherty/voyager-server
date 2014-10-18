using System;

namespace voyagerlib.http
{
	public class HttpRequestLine
	{
		#region Fields
		private HttpMethod _method;
		private string _version;
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
			} set {
				_method = value;
			}
		}

		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <value>The version.</value>
		public string Version {
			get {
				return _version;
			} set {
				_method = value;
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
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.http.HttpRequest"/> structucture.
		/// </summary>
		/// <param name="method">Method.</param>
		/// <param name="path">Path.</param>
		/// <param name="version">Version.</param>
		public HttpRequestLine (HttpMethod method, string path, string version)
		{
			_method = method;
			_path = path;
			_version = version;
		}
		#endregion
	}
}

