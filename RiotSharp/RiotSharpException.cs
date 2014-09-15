using System;

namespace RiotSharp
{
    /// <summary>
    /// RiotSharp exception.
    /// </summary>
    public class RiotSharpException: Exception
    {
        public RiotSharpException() { }

        public RiotSharpException(string message)
            : base(message) { }

        public RiotSharpException(string message, Exception inner)
            : base(message, inner) { }
    }
}
