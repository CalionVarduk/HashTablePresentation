using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HashTableLib;

namespace HashTablePresentation
{
    public partial class HashMapView : Panel
    {
        private Label hashPanel;

        public Point HashPanelLocation
        {
            get { return hashPanel.Location; }
            set { hashPanel.Location = value; }
        }

        public Size HashPanelSize
        {
            get { return hashPanel.Size; }
            set { hashPanel.Size = value; }
        }

        private List<BucketView> buckets;
        public BucketView this[int index]
        {
            get { return buckets[index]; }
        }

        public int Count
        {
            get { return buckets.Count; }
            set
            {
                int count = Count;
                if (count < value)
                {
                    for (int i = count; i < value; ++i)
                        buckets.Add(new BucketView() { Parent = this, Index = i });
                }
                else if (count > value)
                {
                    for (int i = value; i < count; ++i)
                        buckets[i].Parent = null;

                    buckets.RemoveRange(value, count - value);
                }
            }
        }

        private Point bucketsLocation;
        public Point BucketsLocation
        {
            get { return bucketsLocation; }
            set
            {
                bucketsLocation = value;
                ResetLocations();
            }
        }

        public Size BucketsSize
        {
            get
            {
                Point rightBottom = bucketsLocation;
                
                int count = Count;
                for (int i = 0; i < count; ++i)
                {
                    var bucket = buckets[i];
                    if (rightBottom.X < bucket.Right) rightBottom.X = bucket.Right;
                    if (rightBottom.Y < bucket.Bottom) rightBottom.Y = bucket.Bottom;

                    int itCount = bucket.Count;
                    for(int j = 0; j < itCount; ++j)
                    {
                        var item = bucket[j];
                        if (rightBottom.X < item.Right) rightBottom.X = item.Right;
                        if (rightBottom.Y < item.Bottom) rightBottom.Y = item.Bottom;
                    }
                }
                return new Size(rightBottom.X - bucketsLocation.X, rightBottom.Y - bucketsLocation.Y);
            }
        }

        private int bucketSpacing;
        public int BucketSpacing
        {
            get { return bucketSpacing; }
            set
            {
                bucketSpacing = value;
                ResetLocations();
            }
        }

        public int ItemCount
        {
            get
            {
                int allCount = 0;
                int count = Count;
                for (int i = 0; i < count; ++i)
                    allCount += buckets[i].Count;
                return allCount;
            }
        }

        public float LoadFactor { get { return ItemCount / (float)Count; } }

        public HashMapView(int size)
        {
            hashPanel = new Label();
            hashPanel.BorderStyle = BorderStyle.FixedSingle;
            hashPanel.BackColor = Color.SteelBlue;
            hashPanel.ForeColor = Color.White;
            hashPanel.TextAlign = ContentAlignment.MiddleCenter;
            hashPanel.Text = "KEY HASHING";
            hashPanel.Font = new Font(Control.DefaultFont.FontFamily, 13);
            hashPanel.AutoSize = false;
            hashPanel.Parent = this;

            buckets = new List<BucketView>();
            for (int i = 0; i < size; ++i)
                buckets.Add(new BucketView() { Parent = this, Index = i });

            bucketSpacing = 2;
            BucketsLocation = new Point(400, 5);

            InitializeComponent();
        }

        public int HashIndexOf(ItemView view)
        {
            int hash = view.Hash % Count;
            return (hash < 0) ? hash + Count : hash;
        }

        public BucketView BucketOf(ItemView view)
        {
            return buckets[HashIndexOf(view)];
        }

        public void AddItem(ItemView view, int bucketIndex)
        {
            var bucket = buckets[bucketIndex];
            view.ShowHash = true;
            bucket.AddItem(view);
            bucket.ResetItemsBounds();
        }

        public void RemoveItem(ItemView view, int bucketIndex)
        {
            var bucket = buckets[bucketIndex];
            bucket.RemoveItem(view);
            bucket.ResetItemsBounds();
        }

        public void ResizeMap(int newSize)
        {
            if (newSize > 0 && Count != newSize)
            {
                ItemView[] items = ItemArray();

                int count = Count;
                for (int i = 0; i < count; ++i)
                    buckets[i].Clear();

                Count = newSize;
                for(int i = 0; i < items.Length; ++i)
                    BucketOf(items[i]).AddItem(items[i]);

                ResetLocations();
            }
        }

        public ItemView[] ItemArray()
        {
            int count = Count;
            ItemView[] items = new ItemView[ItemCount];

            int index = 0;
            for (int i = 0; i < count; ++i)
            {
                int itCount = buckets[i].Count;
                for (int j = 0; j < itCount; ++j)
                    items[index++] = buckets[i][j];
            }
            return items;
        }

        public void ResetLocations()
        {
            int y = bucketsLocation.Y;

            int count = Count;
            for (int i = 0; i < count; ++i)
            {
                BucketView view = buckets[i];
                view.Location = new Point(bucketsLocation.X, y);
                view.ResetItemsBounds();
                y += view.Height + bucketSpacing;
            }
            ResetHashPanelBounds();
        }

        public void ResetHashPanelBounds()
        {
            Size bSize = BucketsSize;
            hashPanel.Size = new Size(bucketsLocation.X >> 1, bSize.Height >> 1);
            hashPanel.Location = new Point(bucketsLocation.X >> 2, bucketsLocation.Y + bSize.Height >> 2);
            hashPanel.SendToBack();
        }
    }
}
