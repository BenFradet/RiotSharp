// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasteryListStaticWrapper.cs" company="">
//
// </copyright>
// <summary>
//   The mastery list static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The mastery list static wrapper.
    /// </summary>
    class MasteryListStaticWrapper
    {
        /// <summary>
        /// Gets the mastery list static.
        /// </summary>
        public MasteryListStatic MasteryListStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the mastery data.
        /// </summary>
        public MasteryData MasteryData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasteryListStaticWrapper"/> class.
        /// </summary>
        /// <param name="masteries">
        /// The masteries.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="masteryData">
        /// The mastery data.
        /// </param>
        public MasteryListStaticWrapper(MasteryListStatic masteries, Language language, MasteryData masteryData)
        {
            MasteryListStatic = masteries;
            Language = language;
            MasteryData = masteryData;
        }
    }
}
