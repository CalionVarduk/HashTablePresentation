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
    public partial class RemoveItemForm : Form
    {
        private HashMap<string, int> map;
        public string Key { get { return boxKey.Text; } }
        public bool MapResized { get; private set; }

        public RemoveItemForm(HashMap<string, int> map)
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
                MessageBox.Show("Key can't be empty.", "Remove Item Error");
            else
            {
                int oldSize = map.Size;

                if (!map.RemoveKey(Key))
                    MessageBox.Show("Key doesn't exist.", "Remove Item Error");
                else
                {
                    MapResized = (oldSize != map.Size);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
