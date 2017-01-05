namespace HashTablePresentation
{
    partial class SearchItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.boxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.checkValue = new System.Windows.Forms.CheckBox();
            this.boxVal = new System.Windows.Forms.NumericUpDown();
            this.labelVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.boxVal)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(197, 100);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // boxKey
            // 
            this.boxKey.BackColor = System.Drawing.Color.White;
            this.boxKey.Location = new System.Drawing.Point(62, 12);
            this.boxKey.MaxLength = 30;
            this.boxKey.Name = "boxKey";
            this.boxKey.Size = new System.Drawing.Size(210, 20);
            this.boxKey.TabIndex = 7;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(12, 15);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(28, 13);
            this.labelKey.TabIndex = 6;
            this.labelKey.Text = "Key:";
            // 
            // checkValue
            // 
            this.checkValue.AutoSize = true;
            this.checkValue.Location = new System.Drawing.Point(12, 49);
            this.checkValue.Name = "checkValue";
            this.checkValue.Size = new System.Drawing.Size(123, 17);
            this.checkValue.TabIndex = 9;
            this.checkValue.Text = "Change Item\'s Value";
            this.checkValue.UseVisualStyleBackColor = true;
            this.checkValue.CheckedChanged += new System.EventHandler(this.checkValue_CheckedChanged);
            // 
            // boxVal
            // 
            this.boxVal.BackColor = System.Drawing.Color.White;
            this.boxVal.Enabled = false;
            this.boxVal.Location = new System.Drawing.Point(62, 72);
            this.boxVal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.boxVal.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.boxVal.Name = "boxVal";
            this.boxVal.Size = new System.Drawing.Size(210, 20);
            this.boxVal.TabIndex = 11;
            // 
            // labelVal
            // 
            this.labelVal.AutoSize = true;
            this.labelVal.Enabled = false;
            this.labelVal.Location = new System.Drawing.Point(12, 74);
            this.labelVal.Name = "labelVal";
            this.labelVal.Size = new System.Drawing.Size(37, 13);
            this.labelVal.TabIndex = 10;
            this.labelVal.Text = "Value:";
            // 
            // SearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.boxVal);
            this.Controls.Add(this.labelVal);
            this.Controls.Add(this.checkValue);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.boxKey);
            this.Controls.Add(this.labelKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchItemForm";
            this.Text = "Search For Item";
            ((System.ComponentModel.ISupportInitialize)(this.boxVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TextBox boxKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.CheckBox checkValue;
        private System.Windows.Forms.NumericUpDown boxVal;
        private System.Windows.Forms.Label labelVal;
    }
}