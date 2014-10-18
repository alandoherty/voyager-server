using System;

namespace voyagerlib
{
	public static class Utilities
	{
		#region Methods
		/// <summary>
		/// Show a error message in console.
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void Error(string msg) {
			MessageColor (ConsoleColor.Red, "[ERR] " + msg + Environment.NewLine);
		}

		/// <summary>
		/// Show a warning message in console.
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void Warning(string msg) {
			MessageColor (ConsoleColor.Yellow, "[WARN] " + msg + Environment.NewLine);
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
		#endregion
	}
}

