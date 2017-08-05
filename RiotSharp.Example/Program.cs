using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using RiotSharp.Misc;

namespace RiotSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = RiotApi.GetDevelopmentInstance(ConfigurationManager.AppSettings["ApiKey"]);
            var staticApi = StaticRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            var statusApi = StatusRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
            int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);
            Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);
            Platform platform = (Platform)Enum.Parse(typeof(Platform), ConfigurationManager.AppSettings["Platform"]);

            var mastery = staticApi.GetMastery(Region.euw, 6111, MasteryData.All);

            var languages = staticApi.GetLanguages(region);

            Console.WriteLine(string.Join(", ", languages));

            var summ = api.GetSummonerByName(region, name);

            var match1 = api.GetMatch(region, gameId);

            Console.WriteLine(match1.MapType);

            var shardStatus = statusApi.GetShardStatus(region);

            var games = api.GetRecentGames(region, id);

            Console.WriteLine("Done! Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
