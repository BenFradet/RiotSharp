using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Realm.Cache
{
    class RealmStaticWrapper
    {
        [JsonProperty]
        public RealmStatic RealmStatic { get; private set; }

        public RealmStaticWrapper(RealmStatic realm)
        {
            RealmStatic = realm;
        }
    }
}
