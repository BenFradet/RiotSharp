using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    public class CommonTestBase
    {
        protected static IConfigurationRoot Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static string ApiKey = Configuration["ApiKey"];
        public static string FaultyApiKey = "deadbeef-dead-beef-dead-beefdeadbeef";

        public static long InvalidSummonerId = -1;
        public static string Summoner1Id = "fhOx2QJ2VKSaaD9nVJ4XJSzMBPW2es7FboigIwW5ss97coA";
        public static string Summoner1AccountId = "6GwG-_gvthMjC4bMSh-K_n89fXmwAO2r_xW_bydQX6jsQdI";
        public static string Summoner1Name = "toothlessG";
        public static string Summoner1Puuid = "R2RjsXCUB-zJ9T5cZVr1ZI4vVqa3sOR61xRmU71bsJ3o_TCRR_ttdVphhKaD4y57xcvB2AdrNWqGKw";
        public static Region Summoner1Region = (Region)Enum.Parse(typeof(Region), "Na");

        public static string Summoner3Id = "I2QEPYTtazuZge0E31Ge7j8GiPFb2bva7LnJQK1-GJF6";
        public static string Summoner3AccountId = "NRKCQCgDMkctfkkEcC-fEDNX3WwP4Ga8vQWqzdY3dcGL1Ho";
        public static string Summoner3Name = "xsunx";
        public static Region Summoner3Region = (Region)Enum.Parse(typeof(Region), "Ru");

        public static string AccountGameName = "toothlessG";
        public static string AccountTagLine = "NA1";
        public static string AccountPuuid = Summoner1Puuid;

        /// <summary>
        /// Ensures that test returns data (Shows test warnings for 404 status exceptions)
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="message">The message.</param>
        protected void EnsureData(Action action, string message = "Data not found (404).")
        {
            try
            {
                action();
            }
            catch (RiotSharpException exception)
            {
                HandleRiotNotFoundSharpException(exception, message);
                throw;
            }
            // Catches exception thrown by async methods
            catch (AggregateException exception)
            {
                HandleAggregateException(exception, (ex) => HandleRiotNotFoundSharpException(ex, message));
                throw exception;
            }
        }

        /// <summary>
        /// Ignores the test if the server responds with 429/500/503 codes
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

        /// <summary>
        /// Ignores the test if the server responds with 429/500/503 codes
        /// Async Version
        /// </summary>
        /// <param name="action"></param>
        protected async Task EnsureCredibilityAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (RiotSharpException exception)
            {
                HandleRiotSharpException(exception);
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

        private void HandleRiotNotFoundSharpException(RiotSharpException exception, string message)
        {
            if (exception.HttpStatusCode == HttpStatusCode.NotFound)
                Assert.Inconclusive(message);
            throw exception;
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
