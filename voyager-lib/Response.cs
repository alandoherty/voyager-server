
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using voyagerlib.http;

namespace voyagerlib
{
	public class Response
	{
		#region Fields
		private Stream _stream = null;

		private Dictionary<string, HttpHeader> _headers = new Dictionary<string, HttpHeader>();

		private HttpStatusCode _statusCode;
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
		/// Send the data built up in the body.
		/// </summary>
		public void Send() {
			// build
			byte[] statusLine = Utilities.BuildStatusLine ();

			// build headers
			byte[] headers = Utilities.BuildHeaders (_headers);

			_stream.Write (statusLine, 0, statusLine.Length);
			_stream.Write (headers, 0, headers.Length);

			byte[] hello = Encoding.UTF8.GetBytes ("[\n{\n\"name\" : \"The Fadathon\",\n\"description\" : \"We sell fad things here\",\n\"image\" : \"http://jamiehoyle.com/img.png\",\n\"rating\" : 5\n},\n{\n\"name\" : \"The Conferencethon\",\n\"description\" : \"We do conferences\",\n\"image\" : \"http://jamiehoyle.com/img2.png\",\n\"rating\" : 4\n},\n{\n\"name\" : \"The Jamieathon\",\n\"description\" : \"We do anjuli\",\n\"image\" : \"http://jamiehoyle.com/img3.png\",\n\"rating\" : 1\n}\n]");
			_stream.Write (hello, 0, hello.Length);
		}

		/// <summary>
		/// Send a blank response with a status code.
		/// </summary>
		/// <param name="code">Code.</param>
		public void Send(HttpStatusCode code) {

		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerlib.Response"/> class with a stream to write the body to.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public Response (Stream stream)
		{
			_stream = stream;
		}
		#endregion
	}
}

