namespace RiotSharp.Endpoints.StaticDataEndpoint.Realm.Cache
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
