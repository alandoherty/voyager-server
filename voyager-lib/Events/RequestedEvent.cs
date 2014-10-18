using System;

namespace voyagerlib
{
	public delegate void RequestedEventHandler(object sender, RequestEventArgs e);

	public class RequestEventArgs : EventArgs {
		#region Fields
		private Request _req;
		private Response _res;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the request.
		/// </summary>
		/// <value>The request.</value>
		public Request Request {
			get {
				return _req;
			}
		}

		/// <summary>
		/// Gets the response.
		/// </summary>
		/// <value>The response.</value>
		public Response Response {
			get {
				return _res;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.RequestEventArgs"/> class.
		/// </summary>
		/// <param name="req">Req.</param>
		/// <param name="res">Res.</param>
		public RequestEventArgs(Request req, Response res) {
			_req = req;
			_res = res;
		}
		#endregion
	}
}

