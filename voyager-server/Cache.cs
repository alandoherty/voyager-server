using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace voyagerserver
{
	public class Cache
	{
		#region Fields
		private Dictionary<string,string> _searchCache = new Dictionary<string, string>();
		#endregion

		#region Properties
		/// <summary>
		/// Gets the count of search keywords stored.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return _searchCache.Count;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Load from the specified stream
		/// </summary>
		/// <param name="stream">Stream.</param>
		public void Load(Stream stream) {
			// reader
			BinaryReader reader = new BinaryReader (stream);

			// read count
			int keywordCount = reader.ReadInt32 ();

			for (int i = 0; i < keywordCount; i++) {
				// read keyword
				string keyword = reader.ReadString ();

				// json
				string json = reader.ReadString ();

				// add to dictionary
				_searchCache [keyword.ToLower ()] = json;
			}
		}

		/// <summary>
		/// Load cache from filename.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Load(string filename) {
			using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
				Load(fs);
			}
		}

		/// <summary>
		/// Save to the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public void Save(Stream stream) {
			// writer
			BinaryWriter writer = new BinaryWriter (stream);

			// write count
			writer.Write ((Int32)_searchCache.Count);

			// write keyword cache
			foreach (KeyValuePair<string,string> kv in _searchCache) {
				// write keyword
				writer.Write (kv.Key.ToLower ());

				// write compressed json
				writer.Write (kv.Value);
			}
		}

		/// <summary>
		/// Save to a filename.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Save(string filename) {
			using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite)) {
				Save(fs);
			}
		}

		/// <summary>
		/// Check if the key exists.
		/// </summary>
		/// <param name="key">Key.</param>
		public bool Exists(string key) {
			return _searchCache.ContainsKey (key.ToLower());
		}

		/// <summary>
		/// Cache the specified keyword and json.
		/// </summary>
		/// <param name="keyword">Keyword.</param>
		/// <param name="json">Json.</param>
		public void Set(string keyword, string json) {
			_searchCache[keyword.ToLower()] = json;
		}

		/// <summary>
		/// Get the specified json by keyword.
		/// </summary>
		/// <param name="keyword">Keyword.</param>
		public string Get(string keyword) {
			return _searchCache [keyword.ToLower ()];
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="voyagerserver.Cache"/> class.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public Cache(string filename) {
			if (!File.Exists (filename))
				Save (filename);
			else
				Load (filename);
		}
		#endregion
	}
}

