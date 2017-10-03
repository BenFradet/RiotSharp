using System;
using System.Collections.Generic;
using System.Text;
using RiotSharp.Misc;

namespace RiotSharp.Http.Interfaces
{
    public interface IRateLimitProvider
    {
        RateLimiter GetLimiter(Region region);
    }
}
