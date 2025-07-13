using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums
{
    /// <summary>
    /// The division with a <see cref="Tier"/>
    /// </summary>
    [JsonConverter(typeof(DivisionConverter))]
    public enum Division
    {
        /// <summary>Division I</summary>
        I,
        /// <summary>Division II</summary>
        II,
        /// <summary>Division III</summary>
        III,
        /// <summary>Division IV</summary>
        IV
    }
}
