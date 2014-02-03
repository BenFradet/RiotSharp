using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class MasteryTreeStatic
    {
        public List<object> Defense { get; set; }

        public List<object> Offense { get; set; }

        public List<object> Utility { get; set; }
    }
}
