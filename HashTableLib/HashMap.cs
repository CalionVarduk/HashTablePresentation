using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashMap<K, T> : IEnumerable<HashPair<K, T>>
        where K : IEquatable<K>
    {
        private HashTable<HashPair<K, T>> table;

        public T this[K key]
        {
            get { return table[new HashPair<K, T>(key)].Value; }
            set
            {
                HashPair<K, T> hash = new HashPair<K, T>(key);

                if (table.Contains(hash))
                    table[hash].Value = value;
                else
                {
                    hash.Value = value;
                    table.Insert(hash);
                }
            }
        }

        public int MinimumSize
        {
            get { return table.MinimumSize; }
            set { table.MinimumSize = value; }
        }

        public int MaximumSize
        {
            get { return table.MaximumSize; }
            set { table.MaximumSize = value; }
        }

        public int Count { get { return table.Count; } }
        public bool IsEmpty { get { return table.IsEmpty; } }

        public int Size
        {
            get { return table.Size; }
            set { table.Size = value; }
        }

        public float AutoShrinkingFactor{ get { return table.AutoShrinkingFactor; } }
        public bool IsAutoShrinking { get { return table.IsAutoShrinking; } }

        public float AutoExpandingFactor { get { return table.AutoExpandingFactor; } }
        public bool IsAutoExpanding { get { return table.IsAutoExpanding; } }

        public bool IsAutoResizing { get { return table.IsAutoResizing; } }

        public float LoadFactor { get { return table.LoadFactor; } }

        public HashMap()
            : this(1)
        { }

        public HashMap(int size)
        {
            table = new HashTable<HashPair<K, T>>(size);
        }

        public HashMap(HashMap<K, T> other)
        {
            table = new HashTable<HashPair<K, T>>(other.table);
        }

        public int HashIndexOf(K key)
        {
            return table.HashIndexOf(new HashPair<K, T>(key));
        }

        public void IndexOf(K key, out int bucketIndex, out int index)
        {
            table.IndexOf(new HashPair<K, T>(key), out bucketIndex, out index);
        }

        public bool ContainsKey(K key)
        {
            return table.Contains(new HashPair<K, T>(key));
        }

        public bool ContainsValue(T val)
        {
            foreach (var t in table)
                if (t.Value.Equals(val)) return true;
            return false;
        }

        public void Insert(K key, T val)
        {
            table.Insert(new HashPair<K, T>(key, val));
        }

        public bool RemoveKey(K key)
        {
            return table.Remove(new HashPair<K, T>(key));
        }

        public bool RemoveValue(T val)
        {
            List<HashPair<K, T>> rem = new List<HashPair<K, T>>();

            foreach (var t in table)
                if (t.Value.Equals(val)) rem.Add(t);

            if (rem.Count > 0)
            {
                foreach (var h in rem)
                    table.Remove(h);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            table.Clear();
        }

        public void EnableAutoShrinking(float autoShrinkingFactor)
        {
            table.EnableAutoShrinking(autoShrinkingFactor);
        }

        public void EnableAutoExpanding(float autoExpandingFactor)
        {
            table.EnableAutoExpanding(autoExpandingFactor);
        }

        public void EnableAutoResizing(float autoShrinkingFactor, float autoExpandingFactor)
        {
            table.EnableAutoResizing(autoShrinkingFactor, autoExpandingFactor);
        }

        public void DisableAutoShrinking()
        {
            table.DisableAutoShrinking();
        }

        public void DisableAutoExpanding()
        {
            table.DisableAutoExpanding();
        }

        public void DisableAutoResizing()
        {
            table.DisableAutoResizing();
        }

        public HashPair<K, T>[] ToArray()
        {
            return table.ToArray();
        }

        public IEnumerator<HashPair<K, T>> GetEnumerator()
        {
            return table.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
