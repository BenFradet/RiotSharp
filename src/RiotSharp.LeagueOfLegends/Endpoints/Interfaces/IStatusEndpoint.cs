using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
    public interface IStatusEndpoint
    {
        Task<PlatformData?> GetPlatformDataAsync(Region region);
    }
}
