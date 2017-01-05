using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HashTableLib;

namespace HashTablePresentation
{
    public partial class AddItemForm : Form
    {
        private HashMap<string, int> map;
        public string Key { get { return boxKey.Text; } }
        public int Value { get { return (int)boxVal.Value; } }
        public bool MapResized { get; private set; }

        public AddItemForm(HashMap<string, int> map)
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
            this.map = map;
            MapResized = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            buttonConfirm.Click -= this.buttonConfirm_Click;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (boxKey.Text.Length == 0)
                MessageBox.Show("Key can't be empty.", "Add Item Error");
            else
            {
                try
                {
                    int oldSize = map.Size;
                    map.Insert(Key, Value);
                    MapResized = (oldSize != map.Size);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch(ArgumentException)
                {
                    MessageBox.Show("Key already exists.", "Add Item Error");
                }
            }
        }
    }
}
