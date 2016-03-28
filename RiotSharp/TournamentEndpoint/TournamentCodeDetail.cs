using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharp.TournamentEndpoint
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

        /// <summary>
        ///     Update the pick type, map, spectator type, or allowed summoners for a code.
        /// </summary>
        /// <param name="allowedSummonerIds">Comma separated list of summoner Ids.</param>
        /// <param name="spectatorType">The spectator type.</param>
        /// <param name="pickType">The pick type.</param>
        /// <param name="mapType">The map type.</param>
        public bool Update(List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType,
            TournamentPickType? pickType, TournamentMapType? mapType)
        {
            return TournamentRiotApi.GetInstance()
                .UpdateTournamentCode(Code, allowedSummonerIds, spectatorType, pickType, mapType);
        }

        /// <summary>
        ///     Update the pick type, map, spectator type, or allowed summoners for a code asynchronously.
        /// </summary>
        /// <param name="allowedSummonerIds">Comma separated list of summoner Ids.</param>
        /// <param name="spectatorType">The spectator type.</param>
        /// <param name="pickType">The pick type.</param>
        /// <param name="mapType">The map type.</param>
        public async Task<bool> UpdateAsync(List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType,
            TournamentPickType? pickType, TournamentMapType? mapType)
        {
            return await TournamentRiotApi.GetInstance()
                .UpdateTournamentCodeAsync(Code, allowedSummonerIds, spectatorType, pickType, mapType);
        }

        /// <summary>
        ///     Returns the tournament code object associated with a tournament code string.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>the tournament code object associated with a tournament code string.</returns>
        public static TournamentCodeDetail Get(string tournamentCode)
        {
            return TournamentRiotApi.GetInstance().GetTournamentCodeDetails(tournamentCode);
        }

        /// <summary>
        ///     Returns the tournament code object associated with a tournament code string asynchronously.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>the tournament code object associated with a tournament code string.</returns>
        public static async Task<TournamentCodeDetail> GetAsync(string tournamentCode)
        {
            return await TournamentRiotApi.GetInstance().GetTournamentCodeDetailsAsync(tournamentCode);
        }
    }
}
