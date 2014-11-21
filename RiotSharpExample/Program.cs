using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
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

            var summoner = api.GetSummoner(Region.euw, "TommyTrueLove");
            var stats = summoner.GetStatsSummaries();
            foreach (var stat in stats)
            {
                Console.WriteLine(stat.Wins);
            }

            var shards = statusApi.GetShards();

            var shardStatus = statusApi.GetShardStatus(Region.euw);

            var statSummaries = api.GetStatsSummaries(Region.euw, id);

            var statsRanked = api.GetStatsRanked(Region.euw, id, RiotSharp.StatsEndpoint.Season.Season4);

            foreach (var stat in statsRanked)
            {
                Console.WriteLine(stat.Stats.RankedSoloGamesPlayed);
            }

            var championIds = new List<int>();
            for (int i = 0; i < 30; i += 15)
            {
                var matches = api.GetMatchHistory(Region.euw, id, i, i + 15, null,
                    new List<Queue>() { Queue.RankedSolo5x5 });
                foreach (var match in matches)
                {
                    championIds.Add(match.Participants[0].ChampionId);
                }
            }
            var mostPlayedChampId = championIds.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            var mostPlayedChamp = staticApi.GetChampion(Region.euw, mostPlayedChampId);
            Console.WriteLine(mostPlayedChamp.Name);

            var games = api.GetRecentGames(Region.euw, id);

            Console.ReadLine();
        }
    }
}
