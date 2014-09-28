// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuneListStaticWrapper.cs" company="">
//
// </copyright>
// <summary>
//   The rune list static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The rune list static wrapper.
    /// </summary>
    class RuneListStaticWrapper
    {
        /// <summary>
        /// Gets the rune list static.
        /// </summary>
        public RuneListStatic RuneListStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the rune data.
        /// </summary>
        public RuneData RuneData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuneListStaticWrapper"/> class.
        /// </summary>
        /// <param name="runes">
        /// The runes.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="runeData">
        /// The rune data.
        /// </param>
        public RuneListStaticWrapper(RuneListStatic runes, Language language, RuneData runeData)
        {
            RuneListStatic = runes;
            Language = language;
            RuneData = runeData;
        }
    }
}
