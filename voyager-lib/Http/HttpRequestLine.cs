using System;
using System.Collections.Generic;

namespace voyagerlib.http
{
	public class HttpRequestLine
	{
		#region Fields
		private HttpMethod _method;
		private string _version = "";
		private string _path = "";
		private string _query = "";
		private Dictionary<string,string> _params = null;
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
				_version = value;
			}
		}

		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path {
			get {
				return _path;
			} set {
				_path = value;
			}
		}

		/// <summary>
		/// Gets the query.
		/// </summary>
		/// <value>The query.</value>
		public string Query {
			get {
				return _query;
			}
		}

		/// <summary>
		/// Gets the parameters.
		/// </summary>
		/// <value>The parameters.</value>
		public Dictionary<string,string> Parameters {
			get {
				return _params; 
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
			// main stuff
			_method = method;
			_path = path;
			_version = version;

			// parameter parse
			_params = Utilities.ParseParameters (path);

			// remove query string
			if (_params.Count > 0) {
				// find query begin
				int queryBegin = _path.IndexOf ('?');

				_query = _path.Substring (queryBegin);
				_path = _path.Substring (0, queryBegin);
			}
		}
		#endregion
	}
}

