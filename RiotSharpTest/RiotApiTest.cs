using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static string name = ConfigurationManager.AppSettings["Summoner1Name"];
        private static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        private static string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
        private static string team = ConfigurationManager.AppSettings["Team1Id"];
        private static string team2 = ConfigurationManager.AppSettings["Team2Id"];
        private static int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);
        private static int championId = int.Parse(ConfigurationManager.AppSettings["ChampionId"]);
        private static RiotApi api = RiotApi.GetInstance(apiKey);
        private static Queue queue = Queue.RankedSolo5x5;
        private static Region region = (Region) Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);
        private static RiotSharp.MatchEndpoint.Enums.Season season = RiotSharp.MatchEndpoint.Enums.Season.Season2015;
        private static DateTime beginTime = new DateTime(2015, 01, 01);
        private static DateTime endTime { get { return DateTime.Now; } }
        private static List<long> summonerIds = new List<long>()
        {
            23902591, 19676775, 22653737, 21759506, 22209505, 29299341, 19101354, 22166284, 31730794, 39974593,
            23902591, 22790011, 65450936, 67592203, 39637575, 31272097, 23460015, 38627529, 23902591, 44027682,
            20148263, 61138162, 52450898, 31944743, 22926530, 45019487, 19395392, 23902591, 30916825, 34141832,
            46886818, 30994519, 39241634, 28169062, 57726999, 50925946, 41522929, 31718213, 23902591, 24301336,
            28876579, 21465943, 20359176, 18984263, 22061503, 76817435, 28900842, 23902591, 49777173, 43748875,
            25537355, 25284531, 43748877, 26203312, 33839074, 23902591, 59036943, 23214917, 42900539, 34010653,
            19018526, 33031228, 45777129, 23902591, 20458413, 39682802, 50859594, 25518612, 43240226, 63932884,
            21405713, 27551513, 23041221, 23902591, 44864177, 22922241, 19766814, 24754815, 67857142, 24549825,
            60420048, 32961021, 23902591, 39533020, 19294507, 63897880, 33420487, 40101562, 41146842, 61277247
        };
        private static List<string> teamIds = new List<string>()
        {
            "TEAM-c09dc752-1b57-40bb-8373-cb244a200690",
            "TEAM-3bd1b470-3b57-11e4-8b56-c81f66db96d8",
            "TEAM-f619b780-43bc-11e3-8ac1-782bcb497d6f",
            "TEAM-7df12a20-edb4-11e3-a1bd-782bcb497d6f",
            "TEAM-5914f8c0-d4a0-11e4-ae33-c81f66db920c",
            "TEAM-47b21030-0937-11e3-b73e-782bcb4ce61a",
            "TEAM-fa862d00-498a-11e5-8d7f-c81f66dd7106",
            "TEAM-462d4230-63c0-11e5-88c0-c81f66daeaa4",
            "TEAM-70bcb400-ba3b-11e5-b50f-c81f66dd30e5",
            "TEAM-5bfca170-a07f-11e2-b354-782bcb4ce61a",
            "TEAM-b11619d0-7e83-11e6-b377-c81f66dd7106",
            "TEAM-943f2d30-800c-11e6-97fc-c81f66dd32cd"
        };
        private static List<string> summonerNames = new List<string>()
        {
            "Hüxün", "Huikkeli", "poppego", "Masvell", "The 4th Legend", "D4rKAn1mA", "JamboJambo", "MamBoBamos",
            "T0mbs", "uNluckY WallAce", "besni leptir", "InSoAlWeTrust", "Kalistharu", "mikele1997", "Rikudö",
            "Ironíc", "ThaKinetic", "Level 7 Fiora", "Vodkah", "Vayne Only xD", "PF Chang Himself", "Oooshun Man",
            "Paxwell", "Matsyboy", "KingBronko", "chat off", "d3gvsdo", "vipkossEUW", "Monkeyvillage",
            "Synergizing", "iEvoile", "Cthlulu", "LelushLamperysh", "Press RR", "pfulius", "127 II StPO",
            "El Bananero", "Jadi", "Wyburn", "The Vegan God", "Guztavo", "KebapRocker", "Potion Shop"
        };

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var summoner = api.GetSummoner(region, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(region, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            var summoners = api.GetSummoners(Region.euw, summonerIds);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(summonerIds.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, summonerIds);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(summonerIds.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var summoner = api.GetSummoner(region, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(region, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            var summoners = api.GetSummoners(Region.euw, summonerNames);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(summonerNames.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, summonerNames);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(summonerNames.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var summoner = api.GetSummonerName(region, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var summoner = api.GetSummonerNameAsync(region, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            var summoners = api.GetSummonerNames(Region.euw, summonerIds);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(summonerIds.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            var summoners = api.GetSummonerNamesAsync(Region.euw, summonerIds);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(summonerIds.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(region);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(region);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            var champions = api.GetChampions(region, true);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() == 10);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            var champions = api.GetChampionsAsync(region, true);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() == 10);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var champion = api.GetChampion(region, 12);

            Assert.IsNotNull(champion);
            Assert.AreEqual(champion.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champion = api.GetChampionAsync(region, 12);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual(champion.Result.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(Region.euw, summonerIds);

            Assert.IsNotNull(masteries);
            Assert.AreEqual(summonerIds.Distinct().Count(), masteries.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(Region.euw, summonerIds);

            Assert.IsNotNull(masteries.Result);
            Assert.AreEqual(summonerIds.Distinct().Count(), masteries.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(Region.euw, summonerIds);

            Assert.IsNotNull(runes);
            Assert.AreEqual(summonerIds.Distinct().Count(), runes.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(Region.euw, summonerIds);

            Assert.IsNotNull(runes.Result);
            Assert.AreEqual(summonerIds.Distinct().Count(), runes.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeagues(Region.euw, summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(summonerIds.Distinct().Count() - 4, leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesAsync(Region.euw, summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(summonerIds.Distinct().Count() - 4, leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeagues(Region.euw, summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(summonerIds.Distinct().Count() - 4, leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(Region.euw, summonerIds);

            Assert.IsNotNull(leagues.Result);
            Assert.AreEqual(summonerIds.Distinct().Count() - 4, leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_ByTeam_Test()
        {
            var leagues = api.GetLeagues(Region.euw, teamIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(4, leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetLeaguesAsync(Region.euw, teamIds);

            Assert.IsNotNull(leagues.Result);
            Assert.AreEqual(4, leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_ByTeam_Test()
        {
            var leagues = api.GetEntireLeagues(Region.euw, teamIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(4, leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(Region.euw, teamIds);

            Assert.IsNotNull(leagues.Result);
            Assert.AreEqual(4, leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeague(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueAsync(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            var league = api.GetMasterLeague(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            var league = api.GetMasterLeagueAsync(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Summoners_Test()
        {
            var teams = api.GetTeams(Region.euw, summonerIds);

            Assert.IsNotNull(teams);
            Assert.IsTrue(summonerIds.Distinct().Count() / 2 < teams.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Summoners_Test()
        {
            var teams = api.GetTeamsAsync(Region.euw, summonerIds);

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(summonerIds.Distinct().Count() / 2 < teams.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Test()
        {
            var teams = api.GetTeams(Region.euw, teamIds);

            Assert.IsNotNull(teams);
            Assert.AreEqual(teamIds.Distinct().Count(), teams.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = api.GetTeamsAsync(Region.euw, teamIds);

            Assert.IsNotNull(teams.Result);
            Assert.AreEqual(teamIds.Distinct().Count(), teams.Result.Count);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            var game = api.GetMatch(region, gameId);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNull(game.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            var game = api.GetMatch(region, gameId, true);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNotNull(game.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            var game = api.GetMatchAsync(region, gameId);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNull(game.Result.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            var game = api.GetMatchAsync(region, gameId, true);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNotNull(game.Result.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Test()
        {
            var matches = api.GetMatchList(region, id).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_ChampionIds_Test()
        {
            var matches = api.GetMatchList(region, id, new List<long> { championId }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId.ToString(), match.ChampionID.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_RankedQueues_Test()
        {
            var matches = api.GetMatchList(region, id, null, new List<Queue> { queue }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.Queue.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Seasons_Test()
        {
            var matches = api.GetMatchList(region, id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { season }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(season.ToString(), match.Season.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_DateTimes_Test()
        {
            var matches = api.GetMatchList(region, id, null, null, null, beginTime, endTime).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api.GetMatchList(region, id, null, null, null, null, null, beginIndex, endIndex).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            var matches = api.GetMatchListAsync(region, id).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            var matches = api.GetMatchListAsync(region, id, new List<long> { championId }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId.ToString(), match.ChampionID.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_RankedQueues_Test()
        {
            var matches = api.GetMatchListAsync(region, id, null, new List<Queue> { queue }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.Queue.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            var matches = api.GetMatchListAsync(region, id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { season }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(season.ToString(), match.Season.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
        {
            var matches = api.GetMatchListAsync(region, id, null, null, null, beginTime, endTime).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api
                .GetMatchListAsync(region, id, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_Test()
        {
            var stats = api.GetStatsSummaries(region, id, RiotSharp.StatsEndpoint.Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = api.GetStatsSummariesAsync(region, id, RiotSharp.StatsEndpoint.Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummaries(region, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummariesAsync(region, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_Test()
        {
            var stats = api.GetStatsRanked(region, id, RiotSharp.StatsEndpoint.Season.Season2015);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = api.GetStatsRankedAsync(region, id, RiotSharp.StatsEndpoint.Season.Season2015);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = api.GetStatsRanked(region, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsRankedAsync(region, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            var games = api.GetRecentGames(region, id);

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = api.GetRecentGamesAsync(region, id);

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            var games = api.GetFeaturedGames(region);

            Assert.IsNotNull(games);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            var games = api.GetFeaturedGamesAsync(region);

            Assert.IsNotNull(games.Result);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMastery_Test()
        {
            const int lucianId = 236;
            var championMastery = api.GetChampionMastery(Platform.NA1, id, lucianId);

            Assert.IsNotNull(championMastery);
            Assert.AreEqual(id, championMastery.PlayerId);
            Assert.AreEqual(lucianId, championMastery.ChampionId);
            Assert.AreEqual(6, championMastery.ChampionLevel);
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            const int lucianId = 236;
            var championMastery = api.GetChampionMasteryAsync(Platform.NA1, id, lucianId).Result;

            Assert.IsNotNull(championMastery);
            Assert.AreEqual(id, championMastery.PlayerId);
            Assert.AreEqual(lucianId, championMastery.ChampionId);
            Assert.AreEqual(6, championMastery.ChampionLevel);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetAllChampionsMasteryEntries_Test()
        {
            const long lucianId = 236;
            var allChampionsMastery = api.GetChampionMasteries(Platform.NA1, id);

            Assert.IsNotNull(allChampionsMastery);
            Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                championMastery.ChampionId == lucianId));
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAllChampionsMasteryEntriesAsync_Test()
        {
            const long lucianId = 236;
            var allChampionsMastery = api.GetChampionMasteriesAsync(Platform.NA1, id).Result;

            Assert.IsNotNull(allChampionsMastery);
            Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                championMastery.ChampionId == lucianId));
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTotalChampionMasteryScore_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScore(Platform.NA1, id);

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScoreAsync(Platform.NA1, id).Result;

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTopChampionsMasteryEntries_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteries(Platform.NA1, id);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteries(Platform.NA1, id, 6);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTopChampionsMasteryEntriesAsync_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteriesAsync(Platform.NA1, id).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteriesAsync(Platform.NA1, id, 6).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        }
    }
}
