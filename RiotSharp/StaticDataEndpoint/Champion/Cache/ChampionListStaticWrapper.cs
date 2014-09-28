// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChampionListStaticWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The champion list static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The champion list static wrapper.
    /// </summary>
    class ChampionListStaticWrapper
    {
        /// <summary>
        /// Gets the champion list static.
        /// </summary>
        public ChampionListStatic ChampionListStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the champion data.
        /// </summary>
        public ChampionData ChampionData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionListStaticWrapper"/> class.
        /// </summary>
        /// <param name="champions">
        /// The champions.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="championData">
        /// The champion data.
        /// </param>
        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, ChampionData championData)
        {
            ChampionListStatic = champions;
            Language = language;
            ChampionData = championData;
        }
    }
}
