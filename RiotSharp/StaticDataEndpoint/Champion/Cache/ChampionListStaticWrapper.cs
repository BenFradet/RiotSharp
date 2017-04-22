namespace RiotSharp.StaticDataEndpoint
{
    class ChampionListStaticWrapper
    {
        public ChampionListStatic ChampionListStatic { get; private set; }
        public Language Language { get; private set; }
        public ChampionData ChampionData { get; private set; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, ChampionData championData)
        {
            ChampionListStatic = champions;
            Language = language;
            ChampionData = championData;
        }
    }
}
