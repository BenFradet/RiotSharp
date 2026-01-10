using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IStatusEndpoint"/>
    /// </summary>
    public class StatusEndpoint : RateLimitedEndpointBase, IStatusEndpoint
    {
        private const string Url = "/lol/status/v4/platform-data";

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The rate limited requester.</param>
        public StatusEndpoint(IRateLimitedRequester requester) : base(requester)
        { }

        public Task<PlatformData?> GetPlatformDataAsync(Region region)
        {
            return GetContentAsync<PlatformData>(region, Url);
        }
    }
}
