using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
    [Collection("Shared fixture")]
    public class MatchEndpointTest
    {
        private static readonly Region TestRegion = Region.Europe;

        private static readonly string TestMatchId = "EUW1_7216145087";


        private IMatchEndpoint _matchEndpoint;
        private ITestOutputHelper _testOutputHelper;

        public MatchEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            _matchEndpoint = fixture.LeagueOfLegends.Match
                               ?? throw new ArgumentNullException(nameof(fixture), "Match endpoint cannot be null when running Tests!");
        }



    }
}
