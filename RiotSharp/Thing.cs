using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public abstract class Thing
    {
        public static Thing Parse(RiotApi api, JToken json, IRequester requester
            , Region region, Type typeToParse)
        {
            if(typeToParse.Equals(typeof(SummonerBase)))
            {
                return new SummonerBase(api, json, requester, region);
            }
            else if(typeToParse.Equals(typeof(RunePage)))
            {
                return new RunePage(json);
            }
            else if (typeToParse.Equals(typeof(MasteryPage)))
            {
                return new MasteryPage(json);
            }
            else if (typeToParse.Equals(typeof(Champion)))
            {
                return new Champion(json);
            }
            else if (typeToParse.Equals(typeof(Game)))
            {
                return new Game(json);
            }
            else if (typeToParse.Equals(typeof(League)))
            {
                return new League(json);
            }
            else if (typeToParse.Equals(typeof(PlayerStatsSummary)))
            {
                return new PlayerStatsSummary(json);
            }
            else if (typeToParse.Equals(typeof(ChampionStats)))
            {
                return new ChampionStats(json);
            }
            else
            {
                return null;
            }
        }
    }
}
