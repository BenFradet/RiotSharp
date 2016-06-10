namespace RiotSharp.StaticDataEndpoint
{
    class RealmStaticWrapper
    {
        public RealmStatic RealmStatic { get; private set; }

        public RealmStaticWrapper(RealmStatic realm)
        {
            RealmStatic = realm;
        }
    }
}
