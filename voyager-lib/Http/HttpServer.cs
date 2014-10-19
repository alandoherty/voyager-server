using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace voyagerlib.http
{
	public class HttpServer
	{
		#region Fields
		private TcpListener _listener = null;
		private int _port = 8080;
		private Thread _thread = null;

		private int _clientCount = 0;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the port.
		/// </summary>
		/// <value>The port.</value>
		public int Port {
			get {
				return _port;
			}
		}

		/// <summary>
		/// Gets the count of connected clients.
		/// </summary>
		/// <value>The client count.</value>
		public int ClientCount {
			get {
				return _clientCount;
			}
		}
		#endregion

		#region Events
		public event RequestedEventHandler Requested;
		#endregion

		#region Methods
		/// <summary>
		/// Raises the requested event.
		/// </summary>
		/// <param name="e">Event Arguments.</param>
		protected virtual void OnRequested(RequestEventArgs e) {
			if (Requested != null) 
				Requested(this, e);
		}

		/// <summary>
		/// Run the server.
		/// </summary>
		private void Run() {
			while (true) {
				// try to run loop
				try {
					Loop();
				} catch(Exception ex) {
					// display crash message
					Utilities.Error ("Crashed during server loop: " + ex.Message + Environment.NewLine + ex.StackTrace);

					// wait some time
					Thread.Sleep (1000);
				}
			}
		}

		/// <summary>
		/// Loop.
		/// </summary>
		private void Loop()
		{
			while (true) {
				// accept client
				TcpClient client = _listener.AcceptTcpClient ();

				// spawn a thread
				Thread clientThread = new Thread (new ParameterizedThreadStart (Handle));
				clientThread.Name = "VoyagerHttpClient";
				clientThread.Start (client
				);

				// increment client counter
				_clientCount++;

				// warn if clients surpass 10
				if (_clientCount > 10)
					Utilities.Warning ("Too many clients, count " + _clientCount);
			}
		}



		/// <summary>
		/// Handle a client.
		/// </summary>
		/// <param name="client">Client.</param>
		private void Handle(object clientObj) {
			// cast to TcpClient
			TcpClient client = (TcpClient)clientObj;

			// stream reader
			using (StreamReader reader = new StreamReader (client.GetStream ())) {
				// request line
				HttpRequestLine requestLine = reader.ReadHttpRequestLine ();

				// headers
				Dictionary<string, HttpHeader> headers = reader.ReadHttpHeaders ();
			
				// request
				Request req = new Request (requestLine, headers);

				// response
				Response res = new Response (client.GetStream());

				// call requested
				OnRequested (new RequestEventArgs (req, res));
			}

			// close connection (bye)
			client.Close ();

			// decrement count
			_clientCount--;
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			// start listening
			_listener.Start ();

			// start thread

			_thread.Start ();
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop() {
			// abort thread
			_thread.Abort ();

			// stop listening
			_listener.Stop ();
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerserver.HttpServer"/> class.
		/// </summary>
		/// <param name="port">Port.</param>
		public HttpServer (int port)
		{
			// variables
			_port = port;

			// thread
			_thread = new Thread (new ThreadStart (Run));
			_thread.Name = "VoyagerHttpServer";

			// listener
			_listener = new TcpListener (IPAddress.Any, port);
		}
		#endregion
	}
}

