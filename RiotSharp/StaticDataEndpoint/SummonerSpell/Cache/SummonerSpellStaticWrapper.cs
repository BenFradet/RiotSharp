// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummonerSpellStaticWrapper.cs" company="">
//
// </copyright>
// <summary>
//   The summoner spell static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The summoner spell static wrapper.
    /// </summary>
    class SummonerSpellStaticWrapper
    {
        /// <summary>
        /// Gets the summoner spell static.
        /// </summary>
        public SummonerSpellStatic SummonerSpellStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the summoner spell data.
        /// </summary>
        public SummonerSpellData SummonerSpellData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummonerSpellStaticWrapper"/> class.
        /// </summary>
        /// <param name="spell">
        /// The spell.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="summonerSpellData">
        /// The summoner spell data.
        /// </param>
        public SummonerSpellStaticWrapper(SummonerSpellStatic spell, Language language
            , SummonerSpellData summonerSpellData)
        {
            SummonerSpellStatic = spell;
            Language = language;
            SummonerSpellData = summonerSpellData;
        }
    }
}
