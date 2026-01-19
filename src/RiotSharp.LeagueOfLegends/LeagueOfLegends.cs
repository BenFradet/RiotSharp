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

		public ILeagueEndpoint? League { get; }

		public IChallengesEndpoint? Challenges { get; }

		public IStatusEndpoint? Status { get; }

		public IMatchEndpoint? Match { get; }

        /// <summary>
        /// Private constructor to enforce the use of the Builder pattern.
        /// </summary>
        /// <param name="championMastery"></param>
        /// <param name="championRotation"></param>
        /// <param name="clash"></param>
        /// <param name="league"></param>
        private LeagueOfLegends(IChampionMasteryEndpoint? championMastery,
			IChampionRotationEndpoint? championRotation,
			IClashEndpoint? clash,
			ILeagueEndpoint? league,
			IChallengesEndpoint? challenges,
			IStatusEndpoint? status,
			IMatchEndpoint? match)
		{
			ChampionMastery = championMastery;
			ChampionRotation = championRotation;
			Clash = clash;
			League = league;
			Challenges = challenges;
			Status = status;
			Match = match;
        }

		public class Builder
		{
			private IChampionMasteryEndpoint? _championMastery;
			private IChampionRotationEndpoint? _championRotation;
			private IClashEndpoint? _clash;
			private ILeagueEndpoint? _league;
			private IChallengesEndpoint? _challenges;
			private IStatusEndpoint? _status;
			private IMatchEndpoint? _match;
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

			public Builder UseLeagueEndpoint(ILeagueEndpoint endpoint)
			{
				_league = endpoint;
				return this;
			}

			public Builder UseChallengesEndpoint(IChallengesEndpoint endpoint)
			{
				_challenges = endpoint;
				return this;
            }

			public Builder UseStatusEndpoint(IStatusEndpoint endpoint)
			{
				_status = endpoint;
				return this;
            }

			public Builder UseMatchEndpoint(IMatchEndpoint endpoint)
			{
				_match = endpoint;
				return this;
            }

            // ... more UseXEndpoint methods

            public LeagueOfLegends Build()
			{
				// Optionally validate all required endpoints are set
				return new LeagueOfLegends(_championMastery, _championRotation, _clash, _league, _challenges, _status, _match);
			}
		}
	}
}
