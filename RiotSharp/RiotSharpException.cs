using System;
using System.Net;

namespace RiotSharp
{
    /// <summary>
    /// RiotSharp exception.
    /// </summary>
    public class RiotSharpException: Exception
    {
        /// <summary>HTTP error code returned by the Riot API, causing this exception.</summary>
        public readonly HttpStatusCode HttpStatusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public RiotSharpException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
