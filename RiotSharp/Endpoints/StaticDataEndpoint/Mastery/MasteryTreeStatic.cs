using System.Collections.Generic;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery
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
        public List<MasteryTreeListStatic> Defense { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the offense tree.
        /// </summary>
        public List<MasteryTreeListStatic> Offense { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the utility tree.
        /// </summary>
        public List<MasteryTreeListStatic> Utility { get; set; }
    }
}
