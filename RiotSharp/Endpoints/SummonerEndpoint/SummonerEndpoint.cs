using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.SummonerEndpoint
{
    public class SummonerEndpoint : ISummonerEndpoint
    {
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByAccountIdUrl = "/by-account/{0}";
        private const string SummonerByNameUrl = "/by-name/{0}";
        private const string SummonerBySummonerIdUrl = "/{0}";

        private readonly IRateLimitedRequester _requester;

        public SummonerEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public Summoner GetSummonerBySummonerId(Region region, long summonerId)
        {
            var json = _requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var json = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public Summoner GetSummonerByAccountId(Region region, long accountId)
        {
            var json = _requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public Summoner GetSummonerByName(Region region, string summonerName)
        {
            var json = _requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }
    }
}
