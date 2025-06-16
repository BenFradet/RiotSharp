using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.TournamentEndpoint.Enums;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    ///     Class representing the details of a tournament code.
    /// </summary>
    public class TournamentCodeDetail
    {
        internal TournamentCodeDetail()
        {
        }

        /// <summary>
        ///     The tournament code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        ///     The tournament code's ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The lobby name for the tournament code game.
        /// </summary>
        [JsonPropertyName("lobbyName")]
        public string LobbyName { get; set; }

        /// <summary>
        ///     The game map for the tournament code game.
        /// </summary>
        [JsonPropertyName("map")]
        public TournamentMapType Map { get; set; }

        /// <summary>
        ///     The metadata for tournament code.
        /// </summary>
        [JsonPropertyName("metaData")]
        public string MetaData { get; set; }

        /// <summary>
        ///     Set of summoner IDs.
        /// </summary>
        [JsonPropertyName("participants")]
        public HashSet<long> Participants { get; set; }

        /// <summary>
        ///     The password for the tournament code game.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        ///     The pick mode for tournament code game.
        /// </summary>
        [JsonPropertyName("pickType")]
        public TournamentPickType PickType { get; set; }

        /// <summary>
        ///     The provider's ID.
        /// </summary>
        [JsonPropertyName("providerId")]
        public int ProviderId { get; set; }

        /// <summary>
        ///     The tournament code's region.
        /// </summary>
        [JsonPropertyName("region")]
        public Region Region { get; set; }

        /// <summary>
        ///     The spectator mode for the tournament code game.
        /// </summary>
        [JsonPropertyName("spectators")]
        public TournamentSpectatorType SpectatorType { get; set; }

        /// <summary>
        ///     The team size for the tournament code game.
        /// </summary>
        [JsonPropertyName("teamSize")]
        public int TeamSize { get; set; }

        /// <summary>
        ///     The tournament's ID.
        /// </summary>
        [JsonPropertyName("tournamentId")]
        public int TournamentId { get; set; }
    }
}
