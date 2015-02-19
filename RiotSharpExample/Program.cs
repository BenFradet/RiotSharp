using RiotSharp;
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

            var data = staticApi.GetLanguages(Region.euw);

            Console.WriteLine(data);

            var summ = api.GetSummoner(Region.euw, name);

            var teams = summ.GetTeams();

            var match1 = api.GetMatch(Region.euw, 1929054645);

            Console.WriteLine(match1.MapType);

            var shards = statusApi.GetShards();

            var shardStatus = statusApi.GetShardStatus(Region.euw);

            var statSummaries = api.GetStatsSummaries(Region.euw, id);

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
