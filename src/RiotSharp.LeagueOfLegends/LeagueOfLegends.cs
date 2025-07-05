using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.LeagueOfLegends.Endpoints.EndpointInterfaces;

namespace RiotSharp.LeagueOfLegends
{
	/// <summary>
	/// Serves as the main entry point for the League of Legends API.
	/// All endpoints will be accessed through this class.
	/// </summary>
	public class LeagueOfLegends
	{
		public IChampionMasteryEndpoint ChampionMastery { get; }

		public LeagueOfLegends(IChampionMasteryEndpoint championMastery)
		{
			ChampionMastery = championMastery ?? throw new ArgumentNullException(nameof(championMastery), "Champion Mastery endpoint cannot be null.");
		}
		public class Builder
		{
			private IChampionMasteryEndpoint _championMastery;
			// ... more endpoints

			public Builder UseChampionMasteryEndpoint(IChampionMasteryEndpoint endpoint)
			{
				_championMastery = endpoint;
				return this;
			}

			// ... more WithXEndpoint methods

			public LeagueOfLegends Build()
			{
				// Optionally validate all required endpoints are set
				return new LeagueOfLegends(_championMastery);
			}
		}
	}
}
