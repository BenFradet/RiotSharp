// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Requester.cs" company="">
//
// </copyright>
// <summary>
//   The requester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// The requester.
    /// </summary>
    class Requester
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static Requester instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Requester"/> class.
        /// </summary>
        protected Requester()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Requester Instance
        {
            get
            {
                return instance ?? (instance = new Requester());
            }
        }

        /// <summary>
        /// The root domain.
        /// </summary>
        protected string rootDomain;

        /// <summary>
        /// Gets or sets the api key.
        /// </summary>
        public static string ApiKey { get; set; }

        /// <summary>
        /// The create request.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="rootDomain">
        /// The root domain.
        /// </param>
        /// <param name="addedArguments">
        /// The added arguments.
        /// </param>
        /// <param name="useSsl">
        /// The use Ssl.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null, bool useSsl = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useSsl);
            return GetResponse(request);
        }

        /// <summary>
        /// The create request async.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="rootDomain">
        /// The root domain.
        /// </param>
        /// <param name="addedArguments">
        /// The added arguments.
        /// </param>
        /// <param name="useSsl">
        /// The use Ssl.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> CreateRequestAsync(
            string relativeUrl,
            string rootDomain,
            List<string> addedArguments = null,
            bool useSsl = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useSsl);
            return await GetResponseAsync(request);
        }

        /// <summary>
        /// The prepare request.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="addedArguments">
        /// The added arguments.
        /// </param>
        /// <param name="useSsl">
        /// The use Ssl.
        /// </param>
        /// <returns>
        /// The <see cref="HttpWebRequest"/>.
        /// </returns>
        protected HttpWebRequest PrepareRequest(string relativeUrl, List<string> addedArguments, bool useSsl)
        {
            HttpWebRequest request;

            var protocol = useSsl ? "https" : "http";

            if (addedArguments == null)
            {
                request =
                    (HttpWebRequest)
                    WebRequest.Create(string.Format("{0}://{1}{2}?api_key={3}", protocol, rootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request =
                    (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "{0}://{1}{2}?{3}api_key={4}",
                            protocol,
                            rootDomain,
                            relativeUrl,
                            BuildArgumentsString(addedArguments),
                            ApiKey));
            }

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// The get response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetResponse(HttpWebRequest request)
        {
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }

            return string.Empty;
        }

        /// <summary>
        /// The get response async.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<string> GetResponseAsync(HttpWebRequest request)
        {
            try
            {
                var response = (HttpWebResponse)(await request.GetResponseAsync());

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (System.AggregateException aggregate)
            {
                foreach (System.Exception ex in aggregate.InnerExceptions)
                {
                    if (((ex) is WebException))
                    {                        
                        HandleWebException((WebException)ex);
                    }                    
                }

                // Nothing better to do, really… 
                throw;                
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// The build arguments string.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string BuildArgumentsString(List<string> arguments)
        {
            string result = string.Empty;
            foreach (string arg in arguments)
            {
                if (arg != string.Empty)
                {
                    result += arg + "&";
                }
            }

            return result;
        }

        /// <summary>
        /// The handle web exception.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <exception cref="RiotSharpException">
        /// </exception>
        private void HandleWebException(WebException ex)
        {
            var response = (HttpWebResponse)ex.Response;
            switch (response.StatusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    throw new RiotSharpException("503, Service unavailable");
                case HttpStatusCode.InternalServerError:
                    throw new RiotSharpException("500, Internal server error");
                case HttpStatusCode.Unauthorized:
                    throw new RiotSharpException("401, Unauthorized");
                case HttpStatusCode.BadRequest:
                    throw new RiotSharpException("400, Bad request");
                case HttpStatusCode.NotFound:
                    throw new RiotSharpException("404, Resource not found");
            }
        }
    }
}
