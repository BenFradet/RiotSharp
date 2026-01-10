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
    public class StatusEndpointTest
    {
        private static readonly Region TestRegion = Region.Eune;

        private IStatusEndpoint _statusEndpoint;
        private ITestOutputHelper _testOutputHelper;

        public StatusEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            _statusEndpoint = fixture.LeagueOfLegends.Status
                               ?? throw new ArgumentNullException(nameof(fixture), "Status endpoint cannot be null when running Tests!");

        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetPlatformDataAsync_ReturnsPlatformData()
        {
            var result = await _statusEndpoint.GetPlatformDataAsync(TestRegion);
            //_testOutputHelper.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.True(result.Id == "EUN1");
        }
    }
}
