using System;
using System.IO;
using System.Collections.Generic;

namespace voyagerlib.http
{
	public static class HttpExtensions
	{
		#region Methods
		/// <summary>
		/// Reads a HTTP request request.
		/// </summary>
		/// <returns>The request.</returns>
		/// <param name="reader">Reader.</param>
		public static HttpRequestLine ReadHttpRequestLine(this StreamReader reader) {
			// read request line
			string line = reader.ReadLine ();

			// split into sections
			string[] sections = line.Split (' ');

			// check length
			if (sections.Length < 3) {
				Utilities.Error ("Invalid HTTP request " + Environment.NewLine + line);
				return null;
			}

			// method
			HttpMethod method = HttpMethod.GET;

			switch (sections [0].ToUpper()) {
			case "GET":
				method = HttpMethod.GET;
				break;
			case "POST":
				method = HttpMethod.POST;
				break;
			default:
				Utilities.Error ("Invalid method sent in HTTP request " + sections [0]);
				break;
			}

			// build request object
			return new HttpRequestLine (method, sections [1], sections [2]);
		}

		/// <summary>
		/// Reads the http headers.
		/// </summary>
		/// <returns>The http headers.</returns>
		/// <param name="reader">Reader.</param>
		public static Dictionary<string, HttpHeader> ReadHttpHeaders(this StreamReader reader) {
			// read header
			string header = reader.ReadLine ();

			// headers
			Dictionary<string, HttpHeader> headers = new Dictionary<string, HttpHeader> ();

			// loop through all headers
			while (header != "") {
				// split and read
				string[] sections = header.Split (':');

				// check length
				if (sections.Length < 2) {
					Utilities.Error ("Invalid header provided " + header);
					return null;
				}

				// store and trim
				string name = sections [0].Trim ();
				string value = sections [1].Trim ();

				// store header
				headers.Add (name, new HttpHeader(name, value));

				// read another header
				header = reader.ReadLine ();
			}

			// build header object
			return headers;
		}
		#endregion
	}
}

