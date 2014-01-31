using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public class StaticRiotApi
    {
        private Requester requester;

        private static StaticRiotApi instance;
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null || apiKey != Requester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey)
        {

        }
    }
}
