using System;
using RiotSharp;
using RiotSharp.Caching;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var api = RiotApi.GetDevelopmentInstance("RGAPI-97e62090-da1e-453e-b1c2-722ad060c0d0");
            // ID : 79Ks2KwGjbX3ar0InA4SZoo5VhBffkYmvjHIFfCNzWqtiZM
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(Region.Eun1, "Feeding King");

                var matchlist = api.Match.GetMatchAsync(Region.Euw, 3518102254).Result;
                Console.WriteLine(matchlist.GameId);
            }
            catch
            {

            }
        }
    }
}
