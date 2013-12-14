using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Collection<T> : IEnumerable<T> where T : Thing
    {
        private IRequester requester;
        private RiotApi api;
        private JToken json;
        private String collectionName;
        private Region region;

        internal Collection(RiotApi api, JToken json, IRequester requester, String collectionName, Region region)
        {
            this.requester = requester;
            this.json = json;
            this.api = api;
            this.collectionName = collectionName;
            this.region = region;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CollectionEnumerator<T> : IEnumerator<T> where T : Thing
        {
            private Collection<T> collection;
            private int index;
            private Thing[] array;

            public T Current
            {
                get { return (T)array[index]; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public CollectionEnumerator(Collection<T> collection)
            {
                this.collection = collection;
                index = -1;
                Parse();
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (++index >= array.Count())
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            private void Parse()
            {
                var children = collection.json[collection.collectionName] as JArray;
                array = new Thing[children.Count];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Thing.Parse(collection.api, children[i], collection.requester
                        , collection.region, collection.collectionName);
                }
            }
        }
    }
}
