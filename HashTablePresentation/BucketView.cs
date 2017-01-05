using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTablePresentation
{
    public partial class BucketView : UserControl
    {
        private Panel empty;

        private List<ItemView> items;
        public ItemView this[int index]
        {
            get { return items[index]; }
        }

        public int Count { get { return items.Count; } }

        public int Index { get; set; }

        private SolidBrush textBrush;
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                textBrush.Color = value;
                base.ForeColor = value;
            }
        }

        public override string Text
        {
            get
            {
                return "Bucket " + Index.ToString() + Environment.NewLine + "Count: " + items.Count.ToString();
            }
            set { }
        }

        public int PreferredItemTop
        {
            get { return Top + (int)(Height * 0.1875f + 0.5f); }
        }

        public int PreferredItemHeight
        {
            get { return Bottom - PreferredItemTop; }
        }

        public event ItemEventHandler ItemAdded;
        public event ItemEventHandler ItemRemoved;

        public BucketView()
        {
            empty = new Panel();
            empty.Width = 10;
            empty.BorderStyle = BorderStyle.FixedSingle;
            empty.BackColor = Color.White;

            textBrush = new SolidBrush(ForeColor);
            items = new List<ItemView>();
            Index = 0;

            InitializeComponent();
        }

        public void AddItem(ItemView item)
        {
            items.Add(item);
            item.Parent = Parent;
            if (Count == 1) empty.Visible = false;
            OnItemAdded(new ItemEventArgs(item, Count - 1));
            Refresh();
        }

        public bool RemoveItem(ItemView item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                items.RemoveAt(index);
                item.Parent = null;
                if (Count == 0) empty.Visible = true;
                OnItemRemoved(new ItemEventArgs(item, index));
                Refresh();
                return true;
            }
            return false;
        }

        public void ResetItemsBounds()
        {
            int x = Right - 1;
            int y = PreferredItemTop;
            int itHeight = PreferredItemHeight;

            empty.Location = new Point(x, y);

            int count = Count;
            for(int i = 0; i < count; ++i)
            {
                ItemView item = items[i];
                item.Height = itHeight;
                item.Location = new Point(x, y);
                x += item.Width - 1;
            }
            Refresh();
        }

        public void Clear()
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
                items[i].Parent = null;

            items.Clear();
            Refresh();
        }

        public int PreferredItemLeft(int index)
        {
            int count = Math.Min(Count, index);
            int left = Right - 1;
            for (int i = 0; i < count; ++i)
                left += items[i].Width - 1;
            return left;
        }

        public int IndexOf(ItemView item)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
                if (items[i] == item) return i;
            return -1;
        }

        public ItemView FindByKey(object key)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
                if (key.Equals(items[i].Key)) return items[i];
            return null;
        }

        protected virtual void OnItemAdded(ItemEventArgs e)
        {
            if (ItemAdded != null) ItemAdded(this, e);
        }

        protected virtual void OnItemRemoved(ItemEventArgs e)
        {
            if (ItemRemoved != null) ItemRemoved(this, e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            empty.Parent = Parent;

            int count = Count;
            for (int i = 0; i < count; ++i)
                items[i].Parent = Parent;

            base.OnParentChanged(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            empty.Location = new Point(Right - 1, PreferredItemTop);
            base.OnLocationChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            empty.Location = new Point(Right - 1, PreferredItemTop);
            empty.Height = PreferredItemHeight;
            base.OnSizeChanged(e);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            empty.Visible = (Count == 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(Text, Font, textBrush, (RectangleF)ClientRectangle, ItemView.StringFormat);
        }
    }
}
