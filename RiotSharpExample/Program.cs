using System;
using System.Configuration;
using System.Globalization;
using RiotSharp;

namespace RiotSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = RiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            var staticApi = StaticRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            var statusApi = StatusRiotApi.GetInstance();
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
            string team = ConfigurationManager.AppSettings["Team1Id"];
            string team2 = ConfigurationManager.AppSettings["Team2Id"];

            var shards = statusApi.GetShards();

            var shardStatus = statusApi.GetShardStatus(Region.euw);

            var games = api.GetRecentGames(Region.euw, id);

            Console.ReadLine();
        }
    }
}
