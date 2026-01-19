using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Damage statistics at a specific frame.
    /// </summary>
    public class DamageStats
    {
        [JsonPropertyName("magicDamageDone")]
        public required int MagicDamageDone { get; set; }

        [JsonPropertyName("magicDamageDoneToChampions")]
        public required int MagicDamageDoneToChampions { get; set; }

        [JsonPropertyName("magicDamageTaken")]
        public required int MagicDamageTaken { get; set; }

        [JsonPropertyName("physicalDamageDone")]
        public required int PhysicalDamageDone { get; set; }

        [JsonPropertyName("physicalDamageDoneToChampions")]
        public required int PhysicalDamageDoneToChampions { get; set; }

        [JsonPropertyName("physicalDamageTaken")]
        public required int PhysicalDamageTaken { get; set; }

        [JsonPropertyName("totalDamageDone")]
        public required int TotalDamageDone { get; set; }

        [JsonPropertyName("totalDamageDoneToChampions")]
        public required int TotalDamageDoneToChampions { get; set; }

        [JsonPropertyName("totalDamageTaken")]
        public required int TotalDamageTaken { get; set; }

        [JsonPropertyName("trueDamageDone")]
        public required int TrueDamageDone { get; set; }

        [JsonPropertyName("trueDamageDoneToChampions")]
        public required int TrueDamageDoneToChampions { get; set; }

        [JsonPropertyName("trueDamageTaken")]
        public required int TrueDamageTaken { get; set; }
    }
}
