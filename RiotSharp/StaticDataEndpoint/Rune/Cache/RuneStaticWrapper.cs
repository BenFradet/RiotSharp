// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuneStaticWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The rune static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The rune static wrapper.
    /// </summary>
    class RuneStaticWrapper
    {
        /// <summary>
        /// Gets the rune static.
        /// </summary>
        public RuneStatic RuneStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the rune data.
        /// </summary>
        public RuneData RuneData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuneStaticWrapper"/> class.
        /// </summary>
        /// <param name="rune">
        /// The rune.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="runeData">
        /// The rune data.
        /// </param>
        public RuneStaticWrapper(RuneStatic rune, Language language, RuneData runeData)
        {
            RuneStatic = rune;
            Language = language;
            RuneData = runeData;
        }
    }
}
