using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.CurrentGameEndpoint
{
	/// <summary>
	/// Class representing a BannedChampion in the API.
	/// </summary>
	public class BannedChampion
	{
		/// <summary>
		/// The ID of the banned champion
		/// </summary>
		public long ChampionId { get; set; }

		/// <summary>
		/// The turn during which the champion was banned
		/// </summary>
		public int PickTurn { get; set; }

		/// <summary>
		/// The ID of the team that banned the champion
		/// </summary>
		public long TeamId { get; set; }
	}
}
