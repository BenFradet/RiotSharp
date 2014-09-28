// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummonerSpellListStaticWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The summoner spell list static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The summoner spell list static wrapper.
    /// </summary>
    class SummonerSpellListStaticWrapper
    {
        /// <summary>
        /// Gets the summoner spell list static.
        /// </summary>
        public SummonerSpellListStatic SummonerSpellListStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the summoner spell data.
        /// </summary>
        public SummonerSpellData SummonerSpellData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummonerSpellListStaticWrapper"/> class.
        /// </summary>
        /// <param name="spells">
        /// The spells.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="summonerSpellData">
        /// The summoner spell data.
        /// </param>
        public SummonerSpellListStaticWrapper(SummonerSpellListStatic spells, Language language
            , SummonerSpellData summonerSpellData)
        {
            SummonerSpellListStatic = spells;
            Language = language;
            SummonerSpellData = summonerSpellData;
        }
    }
}
