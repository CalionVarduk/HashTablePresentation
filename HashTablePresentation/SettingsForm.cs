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
    public partial class SettingsForm : Form
    {
        private HashMap<string, int> map;
        public bool MapResized { get; private set; }

        public SettingsForm(HashMap<string, int> map)
        {
            InitializeComponent();

            checkShrink.Checked = map.IsAutoShrinking;
            checkExpand.Checked = map.IsAutoExpanding;
            if (map.IsAutoShrinking) boxShrink.Value = (decimal)map.AutoShrinkingFactor;
            if (map.IsAutoExpanding) boxExpand.Value = (decimal)map.AutoExpandingFactor;

            DialogResult = DialogResult.Abort;
            this.map = map;
            MapResized = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            buttonConfirm.Click -= this.buttonConfirm_Click;
            checkShrink.CheckedChanged -= this.checkShrink_CheckedChanged;
            checkExpand.CheckedChanged -= this.checkExpand_CheckedChanged;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int oldSize = map.Size;

                if (checkShrink.Checked)
                {
                    if (checkExpand.Checked)
                        map.EnableAutoResizing((float)boxShrink.Value, (float)boxExpand.Value);
                    else
                    {
                        map.DisableAutoExpanding();
                        map.EnableAutoShrinking((float)boxShrink.Value);
                    }
                }
                else if (checkExpand.Checked)
                {
                    map.DisableAutoShrinking();
                    map.EnableAutoExpanding((float)boxExpand.Value);
                }
                else map.DisableAutoResizing();

                MapResized = (oldSize != map.Size);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(ArgumentOutOfRangeException exc)
            {
                MessageBox.Show(exc.Message, "Settings Error");
            }
        }

        private void checkShrink_CheckedChanged(object sender, EventArgs e)
        {
            labelShrink.Enabled = checkShrink.Checked;
            boxShrink.Enabled = checkShrink.Checked;
        }

        private void checkExpand_CheckedChanged(object sender, EventArgs e)
        {
            labelExpand.Enabled = checkExpand.Checked;
            boxExpand.Enabled = checkExpand.Checked;
        }
    }
}
