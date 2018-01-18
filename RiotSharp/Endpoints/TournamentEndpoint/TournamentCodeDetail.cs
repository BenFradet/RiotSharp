using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.TournamentEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.TournamentEndpoint
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
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     The tournament code's ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The lobby name for the tournament code game.
        /// </summary>
        [JsonProperty("lobbyName")]
        public string LobbyName { get; set; }

        /// <summary>
        ///     The game map for the tournament code game.
        /// </summary>
        [JsonProperty("map")]
        public TournamentMapType Map { get; set; }

        /// <summary>
        ///     The metadata for tournament code.
        /// </summary>
        [JsonProperty("metaData")]
        public string MetaData { get; set; }

        /// <summary>
        ///     Set of summoner IDs.
        /// </summary>
        [JsonProperty("participants")]
        public HashSet<long> Participants { get; set; }

        /// <summary>
        ///     The password for the tournament code game.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        ///     The pick mode for tournament code game.
        /// </summary>
        [JsonProperty("pickType")]
        public TournamentPickType PickType { get; set; }

        /// <summary>
        ///     The provider's ID.
        /// </summary>
        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        /// <summary>
        ///     The tournament code's region.
        /// </summary>
        [JsonProperty("region")]
        public Region Region { get; set; }

        /// <summary>
        ///     The spectator mode for the tournament code game.
        /// </summary>
        [JsonProperty("spectators")]
        public TournamentSpectatorType SpectatorType { get; set; }

        /// <summary>
        ///     The team size for the tournament code game.
        /// </summary>
        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        /// <summary>
        ///     The tournament's ID.
        /// </summary>
        [JsonProperty("tournamentId")]
        public int TournamentId { get; set; }
    }
}
