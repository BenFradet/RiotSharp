using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RiotSharp
{
    /// <summary>
    /// Gets thrown when a request fails because of a rate limit.
    /// </summary>
    public class RiotSharpRateLimitException : RiotSharpException
    {

        /// <summary>
        /// The remaining time before the rate limit resets. Applies to both user and service rate limits.
        /// </summary>
        public readonly TimeSpan RetryAfter;

        /// <summary>
        /// The rate limit type, either method, service, or application. 
        /// Will be null in any 429 response where the rate limit was enforced by the underlying service to which the request was proxied.
        /// </summary>
        public readonly string RateLimitType;

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpRateLimitException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public RiotSharpRateLimitException(string message, HttpStatusCode httpStatusCode, TimeSpan retryAfter, string rateLimitType) : base(message, httpStatusCode)
        {
            RetryAfter = retryAfter;
            RateLimitType = rateLimitType;
        }
    }
}
