using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Damage statistics at a specific frame.
    /// </summary>
    public class DamageStats
    {
        [JsonPropertyName("magicDamageDone")]
        public int MagicDamageDone { get; set; }

        [JsonPropertyName("magicDamageDoneToChampions")]
        public int MagicDamageDoneToChampions { get; set; }

        [JsonPropertyName("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        [JsonPropertyName("physicalDamageDone")]
        public int PhysicalDamageDone { get; set; }

        [JsonPropertyName("physicalDamageDoneToChampions")]
        public int PhysicalDamageDoneToChampions { get; set; }

        [JsonPropertyName("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        [JsonPropertyName("totalDamageDone")]
        public int TotalDamageDone { get; set; }

        [JsonPropertyName("totalDamageDoneToChampions")]
        public int TotalDamageDoneToChampions { get; set; }

        [JsonPropertyName("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [JsonPropertyName("trueDamageDone")]
        public int TrueDamageDone { get; set; }

        [JsonPropertyName("trueDamageDoneToChampions")]
        public int TrueDamageDoneToChampions { get; set; }

        [JsonPropertyName("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }
    }
}
