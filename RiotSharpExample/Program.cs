// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Linq;
using RiotSharp;

namespace RiotSharpExample
{
    /// <summary>
    /// The program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
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

            var sum = api.GetSummoner(Region.euw, id);
            var leagues = sum.GetEntireLeagues();
            var summaries = sum.GetStatsSummaries();

            var summary = summaries.Where(summ => summ.PlayerStatSummaryType == RiotSharp.StatsEndpoint.PlayerStatsSummaryType.RankedSolo5x5)
                .FirstOrDefault();

            Console.WriteLine(summary.PlayerStatSummaryType);
            Console.WriteLine(summary.Losses);
            Console.WriteLine(summary.Wins);
            Console.WriteLine();

            var shards = statusApi.GetShards();

            var shardStatus = statusApi.GetShardStatus(Region.euw);

            var games = api.GetRecentGames(Region.euw, id);

            Console.ReadLine();
        }
    }
}
