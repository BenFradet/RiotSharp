using System;
using System.Configuration;
using RiotSharp.Misc;
using RiotSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace RiotSharpTest
{
    public class CommonTestBase
    {
        public static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        public static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];

        public static Region summoner1and2Region = (Region)Enum.Parse(typeof(Region),
            ConfigurationManager.AppSettings["Summoner1and2Region"]);

        public static long summoner1Id = long.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        public static long summoner1AccountId = long.Parse(ConfigurationManager.AppSettings["Summoner1AccountId"]);
        public static string summoner1Name = ConfigurationManager.AppSettings["Summoner1Name"];

        public static long summoner2Id = long.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        public static long summoner2AccountId = long.Parse(ConfigurationManager.AppSettings["Summoner2AccountId"]);
        public static string summoner2Name = ConfigurationManager.AppSettings["Summoner2Name"];

        /// <summary>
        /// Ignores the test if the server responds with 429 or 500
        /// </summary>
        /// <param name="action"></param>
        protected void EnsureCredibility(Action action)
        {
            try
            {
                action();
            }
            catch (RiotSharpException exception)
            {
                HandleRiotSharpException(exception);
            }
            // Catches exception thrown by async methods
            catch (AggregateException exception)
            {
                HandleAggregateException(exception);
                throw exception;
            }
        }

        private void HandleAggregateException(AggregateException exception)
        {
            if (exception.InnerException != null)
            {
                if (exception.InnerException.GetType() == typeof(RiotSharpException))
                    HandleRiotSharpException((RiotSharpException)exception.InnerException);
                else if (exception.InnerException.GetType() == typeof(AggregateException))
                    HandleAggregateException((AggregateException)exception.InnerException);
                else
                    return; // Go back to root to throw root exception
            }
            else
                return;
        }

        private void HandleRiotSharpException(RiotSharpException exception)
        {
            if (exception.HttpStatusCode == HttpStatusCode.InternalServerError)
                Assert.Inconclusive("Internal server error (500).");
            else if (exception.HttpStatusCode == (HttpStatusCode)429)
                Assert.Inconclusive("Rate limit exceeded (429).");
            else if (exception.HttpStatusCode == HttpStatusCode.ServiceUnavailable)
                Assert.Inconclusive("Service is unavailable (503).");
            else
                throw exception;
        }
    }
}
