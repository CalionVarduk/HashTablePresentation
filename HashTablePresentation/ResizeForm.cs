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
    public partial class ResizeForm : Form
    {
        private HashMap<string, int> map;

        public ResizeForm(HashMap<string, int> map)
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
            this.map = map;
            boxSize.Minimum = map.MinimumSize;
            boxSize.Maximum = map.MaximumSize;
            boxSize.Value = map.Size;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            buttonConfirm.Click -= this.buttonConfirm_Click;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            int newSize = (int)boxSize.Value;

            if (newSize == map.Size)
                MessageBox.Show("Chosen size must be different from the map's current size.", "Resize Error");
            else
            {
                map.Size = newSize;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
