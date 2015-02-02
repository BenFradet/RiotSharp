using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp.CurrentGameEndpoint
{
	/// <summary>
	/// Class representing an Observer in the API.
	/// </summary>
	public class Observer
	{
		/// <summary>
		/// Key required to pass to the LoL client to spectate a game.
		/// </summary>
		[JsonProperty("encryptionKey")]
		public string EncryptionKey { get; set; }
	}
}
