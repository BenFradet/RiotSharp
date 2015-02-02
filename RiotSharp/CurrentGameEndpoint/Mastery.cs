using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp.CurrentGameEndpoint
{
	/// <summary>
	/// Class representing a Mastery in the API.
	/// </summary>
	public class Mastery
	{
		/// <summary>
		/// The ID of the mastery
		/// </summary>
		[JsonProperty("masteryId")]
		public long MasteryId { get; set; }

		/// <summary>
		/// The number of points put into this mastery by the user
		/// </summary>
		[JsonProperty("rank")]
		public int Rank { get; set; }
	}
}
