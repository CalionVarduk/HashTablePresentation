using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePresentation
{
    public class ItemEventArgs : EventArgs
    {
        public ItemView Item { get; private set; }
        public int BucketIndex { get; private set; }

        public ItemEventArgs(ItemView item, int bucketIndex)
        {
            Item = item;
            BucketIndex = bucketIndex;
        }
    }

    public delegate void ItemEventHandler(object sender, ItemEventArgs e);
}
