// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasteryStaticWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The mastery static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The mastery static wrapper.
    /// </summary>
    class MasteryStaticWrapper
    {
        /// <summary>
        /// Gets the mastery static.
        /// </summary>
        public MasteryStatic MasteryStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the mastery data.
        /// </summary>
        public MasteryData MasteryData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasteryStaticWrapper"/> class.
        /// </summary>
        /// <param name="mastery">
        /// The mastery.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="masteryData">
        /// The mastery data.
        /// </param>
        public MasteryStaticWrapper(MasteryStatic mastery, Language language, MasteryData masteryData)
        {
            MasteryStatic = mastery;
            Language = language;
            MasteryData = masteryData;
        }
    }
}
