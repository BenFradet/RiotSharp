using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune
{
    public class ReforgedRunePathStatic
    {
        public List<ReforgedRuneSlotStatic> Slots { get; set; }

        public string Icon { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}
