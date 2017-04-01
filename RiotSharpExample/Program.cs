using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Linq;

namespace RiotSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var api = RiotApi.GetInstance(conf["ApiKey"]);
            var staticApi = StaticRiotApi.GetInstance(conf["ApiKey"]);
            var statusApi = StatusRiotApi.GetInstance();
            int id = int.Parse(conf["Summoner1Id"]);
            string name = conf["Summoner1Name"];
            int id2 = int.Parse(conf["Summoner2Id"]);
            string name2 = conf["Summoner2Name"];
            string team = conf["Team1Id"];
            string team2 = conf["Team2Id"];
            int gameId = int.Parse(conf["GameId"]);
            Region region = (Region)Enum.Parse(typeof(Region), conf["Region"]);

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
