using RiotSharp.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public enum MatchType
    {
        Ranked,
        Normal,
        Tourney,
        Tutorial,
    }

    public class MatchListRequestParameters
    {
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; } = null;
        public int? Queue { get; set; } = null;
        public MatchType? Type { get; set; } = null;
        public int? Start { get; set; } = null;
        public int? Count { get; set; } = null;

        public List<string> ToQueryParameters()
        {
            var queryParameters = new List<string>();
            if (StartTime.HasValue)
                queryParameters.Add($"startTime={StartTime.Value.ToLong()}");
            if (EndTime.HasValue)
                queryParameters.Add($"endTime={EndTime.Value.ToLong()}");
            if (Queue.HasValue)
                queryParameters.Add($"queue={Queue.Value}");
            if (Type.HasValue)
                queryParameters.Add($"type={Type?.ToString().ToLower()}");
            if (Start.HasValue)
                queryParameters.Add($"start={Start.Value}");
            // Should do a check for valid values 0-100
            if (Count.HasValue)
                queryParameters.Add($"count={Count.Value}");
            return queryParameters;
        }
    }

}
