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
    public class Collection<T> : IEnumerable<T> where T : CommonParent
    {
        private IRequester requester;
        private RiotApi api;
        private JToken json;
        private String collectionName;

        internal Collection(RiotApi api, JToken json, IRequester requester, String collectionName)
        {
            this.requester = requester;
            this.json = json;
            this.api = api;
            this.collectionName = collectionName;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CollectionEnumerator<T> : IEnumerator<T> where T : CommonParent
        {
            private Collection<T> listing;
            private int index;
            private CommonParent[] collection;

            public T Current
            {
                get { return (T)collection[index]; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public CollectionEnumerator(Collection<T> listing)
            {
                this.listing = listing;
                index = -1;
                Parse();
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (++index >= collection.Count())
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
                var children = listing.json[listing.collectionName] as JArray;
                collection = new CommonParent[children.Count];
                for (int i = 0; i < collection.Length; i++)
                {
                    collection[i] = CommonParent.Parse(listing.api, children[i], listing.requester); 
                }
            }
        }
    }
}
