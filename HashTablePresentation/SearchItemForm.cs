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
    public partial class SearchItemForm : Form
    {
        private HashMap<string, int> map;
        public string Key { get { return boxKey.Text; } }
        public int NewValue { get; private set; }
        public bool ValueChanged { get { return checkValue.Checked; } }

        public SearchItemForm(HashMap<string, int> map)
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
            this.map = map;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            buttonConfirm.Click -= this.buttonConfirm_Click;
            checkValue.CheckedChanged -= this.checkValue_CheckedChanged;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (boxKey.Text.Length == 0)
                MessageBox.Show("Key can't be empty.", "Search For Item Error");
            else
            {
                if (!map.ContainsKey(Key))
                    MessageBox.Show("Key doesn't exist.", "Search For Item Error");
                else
                {
                    if (ValueChanged)
                    {
                        NewValue = (int)boxVal.Value;
                        map[Key] = NewValue;
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void checkValue_CheckedChanged(object sender, EventArgs e)
        {
            labelVal.Enabled = checkValue.Checked;
            boxVal.Enabled = checkValue.Checked;
        }
    }
}
