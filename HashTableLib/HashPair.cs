using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashPair<K, T> : IEquatable<HashPair<K, T>>
        where K : IEquatable<K>
    {
        public K Key { get; private set; }
        public T Value { get; set; }

        public HashPair(K key)
        {
            Key = key;
        }

        public HashPair(K key, T val)
        {
            Key = key;
            Value = val;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            HashPair<K, T> other = obj as HashPair<K, T>;
            return (other != null) ? Equals(other) : false;
        }

        public bool Equals(HashPair<K, T> other)
        {
            return Key.Equals(other.Key);
        }

        public override string ToString()
        {
            return "Key: " + Key.ToString() + ", Value: " + Value.ToString();
        }
    }
}
