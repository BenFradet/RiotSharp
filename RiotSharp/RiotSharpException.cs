using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public class RiotSharpException: Exception
    {
        public RiotSharpException() { }

        public RiotSharpException(string message)
            : base(message) { }

        public RiotSharpException(string message, Exception inner)
            : base(message, inner) { }
    }
}
