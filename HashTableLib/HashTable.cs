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
        private HashBucket<T>[] buckets;

        public T this[T item]
        {
            get
            {
                HashBucket<T> bucket = BucketOf(item);
                int index = bucket.IndexOf(item);

                if (index == -1)
                    throw new ArgumentOutOfRangeException("Item doesn't exist inside the hash table.");

                return bucket[index];
            }
        }

        private int minSize;
        public int MinimumSize
        {
            get { return minSize; }
            set
            {
                if (value > maxSize)
                    throw new ArgumentException("Minimum size can't be greater than maximum size.");

                minSize = Math.Max(1, value);
                if (Size < minSize) Resize(minSize);
            }
        }

        private int maxSize;
        public int MaximumSize
        {
            get { return maxSize; }
            set
            {
                if (value < minSize)
                    throw new ArgumentException("Maximum size can't be less than minimum size.");

                maxSize = Math.Max(1, value);
                if (Size > maxSize) Resize(maxSize);
            }
        }

        public int Count { get; private set; }
        public bool IsEmpty { get { return (Count == 0); } }

        public int Size
        {
            get { return buckets.Length; }
            set { Resize(value); }
        }

        private float autoShrinkFactor;
        public float AutoShrinkingFactor { get { return autoShrinkFactor; } }
        public bool IsAutoShrinking { get { return (autoShrinkFactor > 0); } }

        private float autoExpandFactor;
        public float AutoExpandingFactor { get { return autoExpandFactor; } }
        public bool IsAutoExpanding { get { return (autoExpandFactor > 0); } }

        public bool IsAutoResizing { get { return (IsAutoShrinking || IsAutoExpanding); } }

        public float LoadFactor { get { return (Count / (float)Size); } }
        
        public HashTable()
            : this(1)
        { }

        public HashTable(int size)
        {
            Count = 0;
            minSize = 1;
            maxSize = int.MaxValue;
            autoShrinkFactor = 0;
            autoExpandFactor = 0;
            InitBuckets(size);
        }

        public HashTable(HashTable<T> other)
        {
            Count = other.Count;
            minSize = other.minSize;
            maxSize = other.maxSize;
            autoShrinkFactor = other.autoShrinkFactor;
            autoExpandFactor = other.autoExpandFactor;

            int size = other.Size;
            buckets = new HashBucket<T>[size];
            for (int i = 0; i < size; ++i)
                buckets[i] = new HashBucket<T>(other.buckets[i]);
        }

        public int HashIndexOf(T item)
        {
            int index = item.GetHashCode() % Size;
            return (index < 0) ? index + Size : index;
        }

        public void IndexOf(T item, out int bucketIndex, out int index)
        {
            bucketIndex = HashIndexOf(item);
            index = buckets[bucketIndex].IndexOf(item);
        }

        public bool Contains(T item)
        {
            return (BucketOf(item).IndexOf(item) != -1);
        }

        public int ItemCount(int bucketIndex)
        {
            return buckets[bucketIndex].Count;
        }

        public void Insert(T item)
        {
            BucketOf(item).Insert(item);
            ++Count;
            if (IsAutoExpanding) TryAutoExpand();
        }

        public bool Remove(T item)
        {
            if (BucketOf(item).Remove(item))
            {
                --Count;
                if (IsAutoShrinking) TryAutoShrink();
                return true;
            }
            return false;
        }

        public void Clear()
        {
            InitBuckets(minSize);
            Count = 0;
        }

        public void Resize(int size)
        {
            if (size < minSize) size = minSize;
            else if (size > maxSize) size = maxSize;

            if(Size != size)
            {
                int oldSize = Size;
                var oldBuckets = buckets;

                Count = 0;
                InitBuckets(size);
                
                for (int i = 0; i < oldSize; ++i)
                {
                    int bucketSize = oldBuckets[i].Count;
                    for (int j = 0; j < bucketSize; ++j)
                        Insert(oldBuckets[i][j]);
                }
            }
        }

        public void EnableAutoShrinking(float autoShrinkingFactor)
        {
            if(!IsAutoShrinking || autoShrinkingFactor != autoShrinkFactor)
            {
                if (autoShrinkingFactor < 0.05f || (IsAutoExpanding && autoShrinkingFactor > (autoExpandFactor * 0.5f)))
                    throw new ArgumentOutOfRangeException("Auto shrinking load factor can't be less than 0.05 or greater than half of the auto expanding load factor.");

                autoShrinkFactor = autoShrinkingFactor;
                TryAutoShrink();
            }
        }

        public void EnableAutoExpanding(float autoExpandingFactor)
        {
            if(!IsAutoExpanding || autoExpandingFactor != autoExpandFactor)
            {
                if (autoExpandingFactor < 0.1f || (IsAutoShrinking && autoShrinkFactor > (autoExpandingFactor * 0.5f)))
                    throw new ArgumentOutOfRangeException("Auto expanding load factor can't be less than 0.1 or less than twice of the auto shrinking load factor.");

                autoExpandFactor = autoExpandingFactor;
                TryAutoExpand();
            }
        }

        public void EnableAutoResizing(float autoShrinkingFactor, float autoExpandingFactor)
        {
            if (autoShrinkingFactor < 0.05f || autoShrinkingFactor > (autoExpandingFactor * 0.5f))
                throw new ArgumentOutOfRangeException("Auto shrinking load factor can't be less than 0.05 or greater than half of the auto expanding load factor.");

            autoShrinkFactor = autoShrinkingFactor;
            autoExpandFactor = autoExpandingFactor;
            float factor = LoadFactor;

            if(factor > autoExpandFactor || factor < autoShrinkFactor)
            {
                float newFactor = (autoShrinkFactor + autoExpandFactor) + 0.5f;
                Resize((int)(Count / newFactor + 0.5f));
            }
        }

        public void DisableAutoShrinking()
        {
            autoShrinkFactor = 0;
        }

        public void DisableAutoExpanding()
        {
            autoExpandFactor = 0;
        }

        public void DisableAutoResizing()
        {
            DisableAutoShrinking();
            DisableAutoExpanding();
        }

        public T[] ToArray()
        {
            int i = 0;
            int size = Size;
            T[] arr = new T[size];

            foreach (var t in this)
                arr[i++] = t;

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new HashTableEnumerator<T>(buckets);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected HashBucket<T> BucketOf(T item)
        {
            return buckets[HashIndexOf(item)];
        }

        private bool TryAutoExpand()
        {
            float factor = LoadFactor;

            if(factor > autoExpandFactor)
            {
                float newFactor = autoShrinkFactor + (autoExpandFactor - autoShrinkFactor) * 0.5f;
                Resize((int)(Count / newFactor + 0.5f));
                return true;
            }
            return false;
        }

        private bool TryAutoShrink()
        {
            float factor = LoadFactor;

            if(factor < autoShrinkFactor)
            {
                float newFactor = (IsAutoExpanding ? (autoShrinkFactor + (autoExpandFactor - autoShrinkFactor) * 0.5f) : (autoShrinkFactor * 1.5f));
                Resize((int)(Count / newFactor + 0.5f));
                return true;
            }
            return false;
        }

        private void InitBuckets(int size)
        {
            buckets = new HashBucket<T>[size];
            for (int i = 0; i < size; ++i)
                buckets[i] = new HashBucket<T>();
        }
    }
}
