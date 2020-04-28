using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.AspNetCore
{
    public enum CacheType
    {
        /// <summary>
        /// Disable caching
        /// </summary>
        None,
        /// <summary>
        /// Use RiotSharp's internal cache implementation for caching (Not recommended)
        /// </summary>
        Internal,
        /// <summary>
        /// Use ASP.NET Core's in-memory cache implementation for caching
        /// </summary>
        Memory,
        /// <summary>
        /// Use ASP.NET Core's distributed cache implementation for caching
        /// </summary>
        Distributed,
        /// <summary>
        /// Use ASP.NET Core's in-memory cache as a primary caching location and distributed as a fallback.
        /// </summary>
        Hybrid,
    }
}
