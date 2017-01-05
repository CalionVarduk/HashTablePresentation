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
    public partial class ItemView : UserControl
    {
        public static readonly StringFormat StringFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        public int Hash { get; private set; }

        private bool showHash;
        public bool ShowHash
        {
            get { return showHash; }
            set
            {
                if (showHash != value)
                {
                    showHash = value;
                    UpdateText();
                }
            }
        }

        private object key;
        public object Key
        {
            get { return key; }
            set
            {
                if (key != value)
                {
                    key = value;
                    Hash = (key != null) ? key.GetHashCode() : -1;
                    UpdateText();
                }
            }
        }

        private object val;
        public object Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    val = value;
                    UpdateText();
                }
            }
        }

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

        private string text;
        public override string Text
        {
            get { return text; }
            set { }
        }

        public Size TextSize
        {
            get
            {
                SizeF size = Graphics.FromHwnd(IntPtr.Zero).MeasureString(text, Font);
                return new Size((int)(size.Width + 0.5f), (int)(size.Height + 0.5f));
            }
        }

        public ItemView()
        {
            textBrush = new SolidBrush(ForeColor);
            InitializeComponent();
            showHash = false;
            Hash = -1;
            UpdateText();
        }

        public void Clear()
        {
            Hash = -1;
            showHash = false;
            key = null;
            Value = null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(text, Font, textBrush, (RectangleF)ClientRectangle, StringFormat);
        }

        private void UpdateText()
        {
            StringBuilder sb = new StringBuilder(100);

            if (ShowHash) sb.Append("[Hash: ").Append(Hash.ToString()).AppendLine("]");
            if (Key != null) sb.Append("[Key: ").Append(Key.ToString()).Append("]");
            if (Value != null) sb.Append((Key != null) ? " => [Value: " : "[Value: ").Append(Value.ToString()).Append("]");

            text = sb.ToString();
        }
    }
}
