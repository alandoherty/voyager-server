using System;
using System.Collections.Generic;
using voyagerlib.http;

namespace voyagerlib
{
	public class Request
	{
		#region Fields
		private Dictionary<string, HttpHeader> _headers;
		private HttpRequestLine _requestLine;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the method.
		/// </summary>
		/// <value>The method.</value>
		public HttpMethod Method {
			get {
				return _requestLine.Method;
			}
		}

		/// <summary>
		/// Gets the headers.
		/// </summary>
		/// <value>The headers.</value>
		public Dictionary<string, HttpHeader> Headers {
			get {
				return _headers;
			}
		}

		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <value>The version.</value>
		public string Version {
			get {
				return _requestLine.Version;
			}
		}

		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path {
			get {
				return _requestLine.Path;
			}
		}

		/// <summary>
		/// Gets the query.
		/// </summary>
		/// <value>The query.</value>
		public string Query {
			get {
				return _requestLine.Query;
			}
		}

		/// <summary>
		/// Gets the parameters.
		/// </summary>
		/// <value>The parameters.</value>
		public Dictionary<string, string> Parameters {
			get {
				if (_requestLine.Method == HttpMethod.GET) {
					return _requestLine.Parameters;
				} else {
					throw new NotImplementedException ();
				}
			}
		}

		/// <summary>
		/// Gets the body.
		/// </summary>
		/// <value>The body.</value>
		public string Body {
			get {
				return "";
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.http.HttpRequest"/> class.
		/// </summary>
		/// <param name="requestLine">Request line.</param>
		/// <param name="headers">Headers.</param>
		public Request (HttpRequestLine requestLine, Dictionary<string, HttpHeader> headers) {
			_headers = headers;
			_requestLine = requestLine;
		}
		#endregion
	}
}

