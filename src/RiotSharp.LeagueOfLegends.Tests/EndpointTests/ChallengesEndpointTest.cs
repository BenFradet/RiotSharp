using NuGet.Frameworks;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
    [Collection("Shared fixture")]
    public class ChallengesEndpointTest
    {
        private static readonly Region TestRegion = Region.Euw;
        private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
        private static readonly long TestChallengeId = 4;
        private static readonly Language TestGermanLanguage = Language.de_DE;
        private static readonly string TestChallengeGermanName = "TEAMARBEIT";
        private static readonly Language TestEnglishName = Language.en_GB;
        private static readonly string TestChallengeEnglishName = "TEAMWORK";

        private IChallengesEndpoint _challengesEndpoint;
        private ITestOutputHelper _testOutputHelper;

        public ChallengesEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            _challengesEndpoint = fixture.LeagueOfLegends.Challenges
                               ?? throw new ArgumentNullException(nameof(fixture), "Challenges endpoint cannot be null when running Tests!");

        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetAllChallengesConfigAsync_HasCorrectInformationTest()
        {
            var result = await _challengesEndpoint.GetChallengeConfigInfoAsync(TestRegion);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.Find(result => result.Id == TestChallengeId)?.LocalizedNames[TestGermanLanguage].Name == TestChallengeGermanName);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetPercentilesAsync_ReturnsCorrectInformationTest()
        {
            var result = await _challengesEndpoint.GetChallengesPercentilesAsync(TestRegion);
            Assert.NotNull(result);
            Assert.True(result.Count > 1);
            Assert.True(result.ContainsKey(TestChallengeId));
            Assert.InRange(result[TestChallengeId][Endpoints.ChallengesEndpoint.Enums.Level.Challenger], 0, 0.009); // Diamond at time of writing this test had ~0.9% percentile
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChallengeConfigByIdAsync_ReturnsCorrectInformationTest()
        {
            var result = await _challengesEndpoint.GetChallengeConfigByIdAsync(TestRegion, TestChallengeId);
            Assert.NotNull(result);
            Assert.Equal(TestChallengeId, result!.Id);
            Assert.Equal(TestChallengeGermanName, result.LocalizedNames[TestGermanLanguage].Name);
            Assert.Equal(TestChallengeEnglishName, result.LocalizedNames[TestEnglishName].Name);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChallengeLeaderboardAsync_ReturnsEmptyListTest()
        {
            var result = await _challengesEndpoint.GetChallengeLeaderboardAsync(TestRegion, TestChallengeId, Endpoints.ChallengesEndpoint.Enums.Level.Challenger);
            Assert.NotNull(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChallengeLeaderboardAsync_ReturnsCorrectInformationTest()
        {
            // These values are chosen because the challenge 4 does not return anything.
            var result = await _challengesEndpoint.GetChallengeLeaderboardAsync(TestRegion, 402404, Endpoints.ChallengesEndpoint.Enums.Level.Master, 5);
            Assert.NotNull(result);
            Assert.True(result.Count == 5);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChallengePercentilesByIdAsync_ReturnsCorrectInformationTest()
        {
            var result = await _challengesEndpoint.GetChallengePercentiles(TestRegion, TestChallengeId);
            Assert.NotNull(result);
            Assert.True(result[Endpoints.ChallengesEndpoint.Enums.Level.None] == 1);
            Assert.InRange(result[Endpoints.ChallengesEndpoint.Enums.Level.Challenger], 0, 0.009);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChallengePlayerInfoAsync_ReturnsCorrectInformationTest()
        {
            var result = await _challengesEndpoint.GetChallengePlayerInfoAsync(TestRegion, TestPuuid);
            Assert.NotNull(result);
            Assert.True(result.Preferences.ChallengeIds.Count == 3);
        }
    }
}