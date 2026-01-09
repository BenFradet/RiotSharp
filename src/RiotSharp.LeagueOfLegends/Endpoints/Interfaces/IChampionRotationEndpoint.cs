using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionRotationEndpoint.Models;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
	/// <summary>
	/// Interface for the Champion Rotation endpoint.
	/// </summary>
	public interface IChampionRotationEndpoint
	{
		/// <summary>
		/// Get the list of free champions by region asynchronously.
		/// </summary>
		/// <param name="region">Region in which you wish to look for champion rotation.</param>
		/// <returns>An object containing id's of champions in rotation as well as max new player level.</returns>
		Task<ChampionRotation?> GetChampionRotationAsync(Region region);
	}
}
