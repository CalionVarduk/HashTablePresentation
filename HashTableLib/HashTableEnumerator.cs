using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public partial class HashTable<T> : IEnumerable<T>
        where T : IEquatable<T>
    {
        private class HashTableEnumerator<U> : IEnumerator<U>
            where U : IEquatable<U>
        {
            private HashBucket<U>[] buckets;
            private int bucketIndex;
            private int index;

            public U Current { get { return buckets[bucketIndex][index]; } }

            object IEnumerator.Current { get { return Current; } }

            public HashTableEnumerator(HashBucket<U>[] buckets)
            {
                this.buckets = buckets;
                bucketIndex = 0;
                index = -1;
            }

            public bool MoveNext()
            {
                if (++index >= buckets[bucketIndex].Count)
                {
                    if (++bucketIndex >= buckets.Length) return false;

                    index = 0;
                    while (buckets[bucketIndex].IsEmpty)
                        if (++bucketIndex >= buckets.Length) return false;
                }
                return true;
            }

            public void Reset()
            {
                bucketIndex = 0;
                index = -1;
            }

            public void Dispose()
            {
                buckets = null;
            }
        }
    }
}
