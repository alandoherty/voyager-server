using System;
using voyagerlib.http;
using System.Reflection;
using System.Collections.Generic;

namespace voyagerlib
{
	public class Server
	{
		#region Fields
		private Assembly _assembly; 
		private HttpServer _http;

		private List<Route> _routes;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the assembly for this server.
		/// </summary>
		/// <value>The assembly.</value>
		public Assembly Assembly {
			get {
				return _assembly;
			}
		}

		/// <summary>
		/// Gets the http server.
		/// </summary>
		/// <value>The server.</value>
		public HttpServer Context {
			get {
				return _http;
			}
		}

		/// <summary>
		/// Gets or sets the routes.
		/// </summary>
		/// <value>The routes.</value>
		public List<Route> Routes {
			get {
				return _routes;
			}
			set {
				_routes = value;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			_http.Start ();
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop() {
			_http.Stop ();
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.Server"/> class.
		/// </summary>
		/// <param name="port">Port.</param>
		public Server (Assembly assembly, int port)
		{
			// assembly
			_assembly = assembly;

			// search for routes
			_routes = new List<Route>(Utilities.SearchRoutes (_assembly));

			// create http server
			_http = new HttpServer (port);

			// event handling
			_http.Requested += new RequestedEventHandler (OnRequested);
		}
		#endregion

		#region Event Handlers
		private void OnRequested(object sender, RequestEventArgs e) {
			foreach (Route route in _routes) {
				if (route.Path == e.Request.Path) {
					route.Function.Invoke (null, new object[]{ e.Request, e.Response });
				}
			}
		}
		#endregion
	}
}

