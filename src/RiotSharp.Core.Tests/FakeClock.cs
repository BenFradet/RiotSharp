using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Time.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Core.Tests
{
    public class FakeClock : FakeTimeProvider, ISystemClock
    {
        public FakeClock(DateTimeOffset startDateTime) : base(startDateTime) { }

        public DateTimeOffset UtcNow => GetUtcNow();
    }
}
