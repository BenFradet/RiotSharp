using System;
using RiotSharp.Misc;
using RiotSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace RiotSharp.Test
{
    public class CommonTestBase
    {
        protected static IConfigurationRoot Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static string ApiKey = Configuration["ApiKey"];
        public static string FaultyApiKey = "deadbeef-dead-beef-dead-beefdeadbeef";

        public static Region Summoner1And2Region = (Region)Enum.Parse(typeof(Region), "na");

        public static long InvalidSummonerId = -1;
        public static long Summoner1Id = 73074921;
        public static long Summoner1AccountId = 231816919;
        public static string Summoner1Name = "toothlessG";

        public static long Summoner2Id = 31815991;
        public static long Summoner2AccountId = 46532395;
        public static string Summoner2Name = "BabyBarf";

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

        protected void HandleAggregateException(AggregateException exception, Action<RiotSharpException> riotSharpExceptionHandler = null)
        {
            if (exception.InnerException != null)
            {
                if (exception.InnerException.GetType() == typeof(RiotSharpException))
                {
                    if (riotSharpExceptionHandler == null)
                        HandleRiotSharpException((RiotSharpException)exception.InnerException);
                    else
                        riotSharpExceptionHandler((RiotSharpException)exception.InnerException);
                }
                else if (exception.InnerException.GetType() == typeof(AggregateException))
                    HandleAggregateException((AggregateException)exception.InnerException, riotSharpExceptionHandler);
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
