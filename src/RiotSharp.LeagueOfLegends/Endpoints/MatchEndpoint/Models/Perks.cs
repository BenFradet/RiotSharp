using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public class Perks
    {
        /// <summary>
        /// Stat perks selected by participant.
        /// </summary>
        [JsonPropertyName("statPerks")]
        public required PerkStats PerkStats { get; set; }

        /// <summary>
        /// Styles and perks selected by participant.
        /// </summary>
        [JsonPropertyName("styles")]
        public required List<PerkStyle> Styles { get; set; }
    }

    public class PerkSelection
    {
        /// <summary>
        /// Perk Id of the <see cref="PerkSelection"/>
        /// </summary>
        [JsonPropertyName("perk")]
        public required int Perk { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var1")]
        public required int Var1 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var2")]
        public required int Var2 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var3")]
        public required int Var3 { get; set; }
    }

    public class PerkStats
    {
        /// <summary>
        /// Perk Id of the defense stat perk.
        /// </summary>
        [JsonPropertyName("defense")]
        public required int Defense { get; set; }

        /// <summary>
        /// Perk Id of the flex stat perk.
        /// </summary>
        [JsonPropertyName("flex")]
        public required int Flex { get; set; }

        /// <summary>
        /// Perk Id of the offense stat perk.
        /// </summary>
        [JsonPropertyName("offense")]
        public required int Offense { get; set; }
    }

    public class PerkStyle
    {
        /// <summary>
        /// Description of the Style. <br/>
        /// Values might be 'primaryStyle' or 'subStyle'
        /// </summary>
        [JsonPropertyName("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Selected perks of this style.
        /// </summary>
        [JsonPropertyName("selections")]
        public required List<PerkSelection> Selections { get; set; }

        /// <summary>
        /// Style Id.
        /// </summary>
        [JsonPropertyName("style")]
        public required int Style { get; set; }
    }
}
