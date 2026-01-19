using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RiotSharp.Core.Misc;

namespace RiotSharp.Account.Endpoints
{
	/// <summary>
	/// Class representing an activeShard.
	/// </summary>
	public class ActiveRegion
	{
		/// <summary>
		/// Encrypted PUUID. Exact length of 78 characters.
		/// </summary>
		[JsonPropertyName("puuid")]
		public required string Puuid { get; set; }

		/// <summary>
		/// The game.
		/// </summary>
		[JsonPropertyName("game")]
		public required Game Game { get; set; }

		/// <summary>
		/// Active shard for combination Puuid and Game.
		/// Has to be a string for now because the API is inconsistent.
		/// </summary>
		[JsonPropertyName("region")]
		public required string Region { get; set; }
	}
}
