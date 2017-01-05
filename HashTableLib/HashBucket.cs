using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public sealed class HashBucket<T>
        where T : IEquatable<T>
    {
        private List<T> items;

        public T this[int index] { get { return items[index]; } }
        public int Count { get { return (IsEmpty ? 0 : items.Count); } }
        public bool IsEmpty { get { return (items == null); } }

        public HashBucket()
        {
            items = null;
        }

        public HashBucket(HashBucket<T> other)
        {
            if (other.IsEmpty) items = null;
            else
            {
                items = new List<T>();
                items.AddRange(other.items);
            }
        }

        public int IndexOf(T item)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
                if (item.Equals(items[i])) return i;
            return -1;
        }

        public void Insert(T item)
        {
            if (IsEmpty) items = new List<T>();
            else if (IndexOf(item) != -1)
                throw new ArgumentException("Item already exists inside the bucket.");

            items.Add(item);
        }

        public bool Remove(T item)
        {
            if (!IsEmpty && items.Remove(item))
            {
                if (items.Count == 0) Clear();
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (!IsEmpty)
            {
                items.RemoveAt(index);
                if (items.Count == 0) Clear();
            }
        }

        public void Clear()
        {
            items = null;
        }
    }
}
