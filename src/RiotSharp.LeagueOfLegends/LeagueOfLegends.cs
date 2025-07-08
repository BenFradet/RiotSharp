using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;

namespace RiotSharp.LeagueOfLegends
{
	/// <summary>
	/// Serves as the main entry point for the League of Legends API.
	/// All endpoints will be accessed through this class.
	/// </summary>
	public class LeagueOfLegends
	{
		public IChampionMasteryEndpoint? ChampionMastery { get; }

		public IChampionRotationEndpoint? ChampionRotation { get; }

		public IClashEndpoint? Clash { get; }

		public LeagueOfLegends(IChampionMasteryEndpoint? championMastery, IChampionRotationEndpoint? championRotation, IClashEndpoint? clash)
		{
			ChampionMastery = championMastery;
			ChampionRotation = championRotation;
			Clash = clash;
		}

		public class Builder
		{
			private IChampionMasteryEndpoint? _championMastery;
			private IChampionRotationEndpoint? _championRotation;
			private IClashEndpoint? _clash;
			// ... more endpoints

			public Builder UseChampionMasteryEndpoint(IChampionMasteryEndpoint endpoint)
			{
				_championMastery = endpoint;
				return this;
			}

			public Builder UseChampionRotationEndpoint(IChampionRotationEndpoint endpoint)
			{
				_championRotation = endpoint;
				return this;
			}

			public Builder UseClashEndpoint(IClashEndpoint endpoint)
			{
				_clash = endpoint;
				return this;
			}

			// ... more WithXEndpoint methods

			public LeagueOfLegends Build()
			{
				// Optionally validate all required endpoints are set
				return new LeagueOfLegends(_championMastery, _championRotation, _clash);
			}
		}
	}
}
