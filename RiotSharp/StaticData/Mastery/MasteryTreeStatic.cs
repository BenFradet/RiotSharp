using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Mastery tree.
    /// </summary>
    public class MasteryTreeStatic
    {
        internal MasteryTreeStatic() { }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the defense tree.
        /// </summary>
        public List<object> Defense { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the offense tree.
        /// </summary>
        public List<object> Offense { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the utility tree.
        /// </summary>
        public List<object> Utility { get; set; }
    }
}
