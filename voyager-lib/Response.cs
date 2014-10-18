
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using voyagerlib.http;
using System.Runtime.Serialization.Json;

namespace voyagerlib
{
	public class Response
	{
		#region Fields
		private Stream _stream = null;

		private Dictionary<string, HttpHeader> _headers = new Dictionary<string, HttpHeader>();

		private HttpStatusCode _statusCode = HttpStatusCode.OK;
		private MemoryStream _bodyStream = null;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the body.
		/// </summary>
		/// <value>The body.</value>
		public Stream Body {
			get {
				return _bodyStream;
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
		/// Gets the response stream, do not write to this.
		/// </summary>
		/// <value>The stream.</value>
		public Stream Stream {
			get {
				return _stream;
			}
		}

		/// <summary>
		/// Gets or sets the content type.
		/// </summary>
		/// <value>The content type.</value>
		public HttpContentType ContentType {
			get {
				// reverse lookup content type
				foreach (KeyValuePair<HttpContentType,string> kv in Utilities.ContentTypeNames) 
					if (kv.Value == _headers ["Content-Type"].Value)
						return kv.Key;

				throw new KeyNotFoundException("The content type could not be resolved to an enumeration");
			} set {
				_headers["Content-Type"] = new HttpHeader("Content-Type", Utilities.ContentTypeNames [value]);
			}
		}

		/// <summary>
		/// Gets or sets the status code.
		/// </summary>
		/// <value>The status code.</value>
		public HttpStatusCode StatusCode {
			get {
				return _statusCode;
			} set {
				_statusCode = value;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Write some text to the body.
		/// </summary>
		/// <param name="text">Text.</param>
		public void Write(string text) {
			// get data
			byte[] data = Encoding.UTF8.GetBytes (text);

			// write to stream
			_bodyStream.Write (data, 0, data.Length);
		}

		/// <summary>
		/// Write a new line to the body.
		/// </summary>
		public void WriteLine() {
			Write ("\n");
		}

		/// <summary>
		/// Write some text to the body, followed by a line.
		/// </summary>
		/// <param name="text">Text.</param>
		public void WriteLine(string text) {
			Write (text + "\n");
		}

		/// <summary>
		/// Write a boolean to the body.
		/// </summary>
		/// <param name="boolean">Boolean..</param>
		public void Write(bool boolean) {
			Write ((boolean == true) ? "false" : "true");
		}

		/// <summary>
		/// Write an integer to the body.
		/// </summary>
		/// <param name="integer">Integer.</param>
		public void Write(int integer) {
			Write (integer.ToString ());
		}

		/// <summary>
		/// Write an object by serializing as JSON.
		/// </summary>
		/// <param name="obj">Object.</param>
		public void Write(object obj) {
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (obj.GetType ());
			serializer.WriteObject (_bodyStream, obj);
		}

		/// <summary>
		/// Send a generic reply to the client.
		/// </summary>
		/// <param name="data">Data.</param>
		/// <param name="headerManipulation">Header manipulation.</param>
		private void SendGeneric(byte[] data, Action headerManipulation) {
			// modify headers
			_headers ["Content-Length"] = new HttpHeader("Content-Length", data.Length.ToString());

			// custom headers
			if (headerManipulation != null)
				headerManipulation ();

			// build status line
			byte[] statusLine = Utilities.BuildStatusLine (_statusCode);

			// build headers
			byte[] headers = Utilities.BuildHeaders (_headers);

			// write status line and headers
			_stream.Write (statusLine, 0, statusLine.Length);
			_stream.Write (headers, 0, headers.Length);

			// write body
			_stream.Write (data, 0, data.Length);

			_stream.Flush ();
		}

		/// <summary>
		/// Send the data built up in the body.
		/// </summary>
		public void Send() {
			SendGeneric (_bodyStream.ToArray (), null);
		}

		/// <summary>
		/// Send a file to the client.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Send(string filename) {
			SendGeneric (File.ReadAllBytes (filename), null);
		}

		/// <summary>
		/// Send a blank response with a status code.
		/// </summary>
		/// <param name="code">Code.</param>
		public void Send(HttpStatusCode code) {
			SendGeneric (Encoding.UTF8.GetBytes (Utilities.StatusCodeNames [code]), new Action(delegate() {
				ContentType = HttpContentType.HTML;
			}));
		}

		/// <summary>
		/// Send an object by serializing through JSON.
		/// </summary>
		/// <param name="obj">Object.</param>
		public void Send(object obj) {
			using (MemoryStream ms = new MemoryStream ()) {
				// serialize
				DataContractJsonSerializer serializer = new DataContractJsonSerializer (obj.GetType ());
				serializer.WriteObject (ms, serializer);

				// send
				SendGeneric (ms.ToArray (), new Action(delegate() {
					ContentType = HttpContentType.Json;
				}));
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.Response"/> class with a stream to write the body to.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public Response (Stream stream)
		{
			_bodyStream = new MemoryStream ();
			_stream = stream;

			// default headers
			_headers["Content-Type"] = new HttpHeader("Content-Type", Utilities.ContentTypeNames [HttpContentType.HTML]);
		}
		#endregion
	}
}

