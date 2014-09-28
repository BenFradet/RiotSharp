// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasteryTreeStatic.cs" company="">
//
// </copyright>
// <summary>
//   Mastery tree.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Mastery tree.
    /// </summary>
    [Serializable]
    public class MasteryTreeStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasteryTreeStatic"/> class.
        /// </summary>
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
