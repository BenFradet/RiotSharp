using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
            int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);
            Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);

            var mastery = staticApi.GetMastery(Region.euw, 6111, MasteryData.all);

            var languages = staticApi.GetLanguages(region);

            Console.WriteLine(string.Join(", ", languages));

            var summ = api.GetSummoner(region, name);

            var teams = summ.GetTeams();

            var match1 = api.GetMatch(region, gameId);

            Console.WriteLine(match1.MapType);

            var shards = statusApi.GetShards();

            var shardStatus = statusApi.GetShardStatus(region);

            var statSummaries = api.GetStatsSummaries(region, id);

            var games = api.GetRecentGames(region, id);

            Console.WriteLine("Done! Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
