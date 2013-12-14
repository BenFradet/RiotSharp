using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Thing
    {
        public static Thing Parse(RiotApi api, JToken json, IRequester requester
            , Region region, String collectionName)
        {
            switch (collectionName)
            {
                case "summoners":
                    return new SummonerBase(api, json, requester, region);
                case "pages":
                    return new RunePage(api, json);
                default:
                    return null;
            }
        }
    }
}
