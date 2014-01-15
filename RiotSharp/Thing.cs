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
        public static Thing Parse(JToken json, IRequester requester, Region region, Type typeToParse)
        {
            if(typeToParse.Equals(typeof(SummonerBase)))
            {
                return new SummonerBase(json.ToString(), requester, region);
            }
            else if(typeToParse.Equals(typeof(RunePage)))
            {
                return new RunePage(json);
            }
            else if (typeToParse.Equals(typeof(MasteryPage)))
            {
                return new MasteryPage(json);
            }
            else if (typeToParse.Equals(typeof(MasteryPageV11)))
            {
                return new MasteryPageV11(json);
            }
            else if (typeToParse.Equals(typeof(Champion)))
            {
                return new Champion(json);
            }
            else if (typeToParse.Equals(typeof(Game)))
            {
                return new Game(json);
            }
            else if (typeToParse.Equals(typeof(GameV12)))
            {
                return new GameV12(json);
            }
            else if (typeToParse.Equals(typeof(GameV11)))
            {
                return new GameV11(json);
            }
            else if (typeToParse.Equals(typeof(League)))
            {
                return new League(json);
            }
            else if (typeToParse.Equals(typeof(LeagueV21)))
            {
                return new LeagueV21(json);
            }
            else if (typeToParse.Equals(typeof(PlayerStatsSummary)))
            {
                return new PlayerStatsSummary(json);
            }
            else if (typeToParse.Equals(typeof(PlayerStatsSummaryV11)))
            {
                return new PlayerStatsSummaryV11(json);
            }
            else if (typeToParse.Equals(typeof(ChampionStats)))
            {
                return new ChampionStats(json);
            }
            else if (typeToParse.Equals(typeof(ChampionStatsV11)))
            {
                return new ChampionStatsV11(json);
            }
            else
            {
                return null;
            }
        }
    }
}
