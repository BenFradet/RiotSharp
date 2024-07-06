using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Realm.Cache
{
    class RealmStaticWrapper
    {
        [JsonInclude]
        public RealmStatic RealmStatic { get; private set; }

        public RealmStaticWrapper(RealmStatic realm)
        {
            RealmStatic = realm;
        }
    }
}
