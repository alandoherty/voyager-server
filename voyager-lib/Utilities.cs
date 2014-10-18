using System;
using voyagerlib.http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Web;

namespace voyagerlib
{
	public static class Utilities
	{
		#region Constants
		public const string HttpVersion = "HTTP/1.1";
		#endregion

		#region Fields
		/// <summary>
		/// The headers required in every request.
		/// </summary>
		public static string[] RequiredHeaders = new string[] {
			"Host"
		};

		/// <summary>
		/// The names assigned to each status code
		/// </summary>
		public static Dictionary<HttpStatusCode,string> StatusCodeNames = new Dictionary<HttpStatusCode, string>()
		{
			{ HttpStatusCode.Continue, "Continue" },
			{ HttpStatusCode.OK, "OK" },
			{ HttpStatusCode.Created, "Created" },
			{ HttpStatusCode.Accepted, "Accepted" },
			{ HttpStatusCode.MovedPermanently, "Moved Permanently" },
			{ HttpStatusCode.Found, "Found" },
			{ HttpStatusCode.TemporaryRedirect, "Temporary Redirect" },
			{ HttpStatusCode.PermanentRedirect, "Permanent Redirect" },
			{ HttpStatusCode.BadRequest, "Bad Request" },
			{ HttpStatusCode.Unauthorized, "Unauthorized" },
			{ HttpStatusCode.PaymentRequired, "Payment Required" },
			{ HttpStatusCode.Forbidden, "Forbidden" },
			{ HttpStatusCode.NotFound, "Not Found" }
		};
		#endregion

		#region Methods
		/// <summary>
		/// Show a error message in console.
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void Error(string msg) {
			MessageColor (ConsoleColor.Red, "[ERR] " + msg + Environment.NewLine);
		}

		/// <summary>
		/// Show a information message in console.
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void Info(string msg) {
			MessageColor (ConsoleColor.Blue, "[INFO] " + msg + Environment.NewLine);
		}

		/// <summary>
		/// Show a request message in console.
		/// </summary>
		/// <param name="method">Method.</param>
		/// <param name="path">Path.</param>
		public static void Log(HttpMethod method, string path) {
			MessageColor (ConsoleColor.Gray, "[REQUEST] " + method.ToString () + " " + path + Environment.NewLine);
		}

		/// <summary>
		/// Show a warning message in console.
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void Warning(string msg) {
			MessageColor (ConsoleColor.Yellow, "[WARN] " + msg + Environment.NewLine + Environment.NewLine);
		}

		/// <summary>
		/// Show a coloured message in console.
		/// </summary>
		/// <param name="clr">Color.</param>
		/// <param name="msg">Message.</param>
		public static void MessageColor(ConsoleColor clr, string msg) {
			// save and change color
			ConsoleColor oldClr = Console.ForegroundColor;
			Console.ForegroundColor = clr;

			// write message
			Console.Write (msg);

			// restore old color
			Console.ForegroundColor = oldClr;
		}

		/// <summary>
		/// Verify the headers list contains basic required headers.
		/// </summary>
		/// <returns>The headers that were missing, or null.returns>
		/// <param name="headers">Headers.</param>
		public static string[] VerifyHeaders(Dictionary<string, HttpHeader> headers) {
			// missing headers
			List<string> missingHeaders = new List<string>();

			// search using array
			foreach (string header in RequiredHeaders) {
				if (!headers.ContainsKey (header))
					missingHeaders.Add (header);
			}

			// return null or headers
			if (missingHeaders.Count == 0)
				return null;
			else
				return missingHeaders.ToArray();
		}

		/// <summary>
		/// Parses the parameters from a path.
		/// </summary>
		/// <returns>The parameters.</returns>
		/// <param name="path">Path.</param>
		public static Dictionary<string,string> ParseParameters(string path) {
			// find query start
			int queryStart = path.IndexOf ('?');

			// parameters
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			// check if exists
			if (queryStart == -1)
				return parameters;

			// get query string
			string queryStr = path.Substring (queryStart + 1);

			// loop through characters
			int parseState = 0;

			// key/value
			string key = "";
			string value = "";

			// parse
			for (int i = 0; i < queryStr.Length; i++) {
				// character
				char c = queryStr [i];

				// state
				if (parseState == 0) {
					// move to value
					if (c == '=') {
						parseState = 1;
						continue;
					}

					key = key + c;
				} else if (parseState == 1) {
					// move to value
					if (c == '&') {
						// add
						parameters.Add (key, HttpUtility.UrlDecode(value));

						// reset
						key = ""; value = "";

						// go back to state zero
						parseState = 0;
					}

					value = value + c;
				}
			}

			// add last key/value
			if (queryStr.Length > 0)
				parameters.Add (key, HttpUtility.UrlDecode(value));

			// params
			return parameters;
		}

		/// <summary>
		/// Convert's a UTF8 string to ASCII.
		/// </summary>
		/// <returns>The ASCII string.</returns>
		/// <param name="text">Text.</param>
		public static string UTF8toASCII(string text)
		{
			System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
			Byte[] encodedBytes = utf8.GetBytes(text);
			Byte[] convertedBytes =
				Encoding.Convert(Encoding.UTF8, Encoding.ASCII, encodedBytes);
			System.Text.Encoding ascii = System.Text.Encoding.ASCII;

			return ascii.GetString(convertedBytes);
		}

		/// <summary>
		/// Check if a method has an attribute.
		/// </summary>
		/// <returns><c>true</c>, if it has the attribute, otherwise <c>false</c>.</returns>
		/// <param name="method">Method.</param>
		/// <param name="attribute">Attribute.</param>
		public static bool MethodHasAttribute(MethodInfo method, Type attribute) {
			return method.GetCustomAttributes(attribute, false).Length > 0;
		}

		/// <summary>
		/// Search for all routes in an assembly.
		/// </summary>
		/// <returns>The routes.</returns>
		/// <param name="assembly">Assembly.</param>
		public static Route[] SearchRoutes(Assembly assembly) {
			// routes
			List<Route> routes = new List<Route> ();

			// get all static classes
			IEnumerable<Type> types = assembly.GetTypes().Where
				(t => t.IsClass && t.IsSealed && t.IsAbstract);

			// search for all types
			foreach (Type type in types) {
				// search all methods
				foreach (MethodInfo method in type.GetMethods()) {
					if (MethodHasAttribute(method, typeof(Route))) {
						// get route attribute
						Route route = method.GetCustomAttribute<Route> ();

						// append method
						route.Function = method;

						// add to routes
						routes.Add(route);
					} else
						continue;
				}
			}

			return routes.ToArray();
		}

		/// <summary>
		/// Build headers to a string.
		/// </summary>
		/// <returns>The headers as a byte array of ASCII.</returns>
		/// <param name="headers">Headers.</param>
		public static byte[] BuildHeaders (Dictionary<string, HttpHeader> headers)
		{
			// builder
			StringBuilder builder = new StringBuilder ();

			// add each header
			foreach (KeyValuePair<string,HttpHeader> header in headers) {
				builder.AppendLine (header.Key + ": " + header.Value.Value);
			}

			// add final line
			builder.AppendLine ();

			return Encoding.ASCII.GetBytes (builder.ToString ());
		}

	
		public static byte[] BuildStatusLine(HttpStatusCode status) {

			return Encoding.ASCII.GetBytes (HttpVersion + " 200 OK\n");
		}
		#endregion
	}
}

