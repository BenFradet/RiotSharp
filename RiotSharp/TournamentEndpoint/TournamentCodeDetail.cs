using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    [Serializable]
    public class TournamentCodeDetail
    {
        internal TournamentCodeDetail() { }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lobbyName")]
        public string LobbyName { get; set; }

        [JsonProperty("map")]
        public TournamentMapType Map { get; set; }

        [JsonProperty("metaData")]
        public string MetaData { get; set; }

        [JsonProperty("participants")]
        public HashSet<long> Participants { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("pickType")]
        public TournamentPickType PickType { get; set; }

        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("spectators")]
        public TournamentSpectatorType Spectators { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("tournamentId")]
        public int TournamentId { get; set; }

        public void Update(List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            TournamentRiotApi.GetInstance().UpdateTournamentCode(Code, allowedSummonerIds, spectatorType, pickType, mapType);
        }

        public async void UpdateAsync(List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            await Task.Factory.StartNew(() => TournamentRiotApi.GetInstance().UpdateTournamentCodeAsync(Code, allowedSummonerIds, spectatorType, pickType, mapType));
        }

        public static TournamentCodeDetail Get(string tournamentCode)
        {
            return TournamentRiotApi.GetInstance().GetTournamentCodeDetails(tournamentCode);
        }

        public static async Task<TournamentCodeDetail> GetAsync(string tournamentCode)
        {
            return await TournamentRiotApi.GetInstance().GetTournamentCodeDetailsAsync(tournamentCode);
        }
    }
}
