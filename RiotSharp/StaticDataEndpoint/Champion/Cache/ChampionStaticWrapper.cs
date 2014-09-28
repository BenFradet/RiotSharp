// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChampionStaticWrapper.cs" company="">
//
// </copyright>
// <summary>
//   The champion static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The champion static wrapper.
    /// </summary>
    class ChampionStaticWrapper
    {
        /// <summary>
        /// Gets the champion static.
        /// </summary>
        public ChampionStatic ChampionStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the champion data.
        /// </summary>
        public ChampionData ChampionData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionStaticWrapper"/> class.
        /// </summary>
        /// <param name="champion">
        /// The champion.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="championData">
        /// The champion data.
        /// </param>
        public ChampionStaticWrapper(ChampionStatic champion, Language language, ChampionData championData)
        {
            ChampionStatic = champion;
            Language = language;
            ChampionData = championData;
        }
    }
}
