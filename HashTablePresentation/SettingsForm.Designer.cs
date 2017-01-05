namespace HashTablePresentation
{
    partial class SettingsForm
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
            this.checkShrink = new System.Windows.Forms.CheckBox();
            this.checkExpand = new System.Windows.Forms.CheckBox();
            this.labelShrink = new System.Windows.Forms.Label();
            this.boxShrink = new System.Windows.Forms.NumericUpDown();
            this.boxExpand = new System.Windows.Forms.NumericUpDown();
            this.labelExpand = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxShrink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxExpand)).BeginInit();
            this.SuspendLayout();
            // 
            // checkShrink
            // 
            this.checkShrink.AutoSize = true;
            this.checkShrink.Location = new System.Drawing.Point(12, 12);
            this.checkShrink.Name = "checkShrink";
            this.checkShrink.Size = new System.Drawing.Size(137, 17);
            this.checkShrink.TabIndex = 0;
            this.checkShrink.Text = "Auto Shrinking Enabled";
            this.checkShrink.UseVisualStyleBackColor = true;
            this.checkShrink.CheckedChanged += new System.EventHandler(this.checkShrink_CheckedChanged);
            // 
            // checkExpand
            // 
            this.checkExpand.AutoSize = true;
            this.checkExpand.Location = new System.Drawing.Point(12, 80);
            this.checkExpand.Name = "checkExpand";
            this.checkExpand.Size = new System.Drawing.Size(143, 17);
            this.checkExpand.TabIndex = 1;
            this.checkExpand.Text = "Auto Expanding Enabled";
            this.checkExpand.UseVisualStyleBackColor = true;
            this.checkExpand.CheckedChanged += new System.EventHandler(this.checkExpand_CheckedChanged);
            // 
            // labelShrink
            // 
            this.labelShrink.AutoSize = true;
            this.labelShrink.Enabled = false;
            this.labelShrink.Location = new System.Drawing.Point(12, 37);
            this.labelShrink.Name = "labelShrink";
            this.labelShrink.Size = new System.Drawing.Size(67, 13);
            this.labelShrink.TabIndex = 2;
            this.labelShrink.Text = "Load Factor:";
            // 
            // boxShrink
            // 
            this.boxShrink.BackColor = System.Drawing.Color.White;
            this.boxShrink.DecimalPlaces = 2;
            this.boxShrink.Enabled = false;
            this.boxShrink.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.boxShrink.Location = new System.Drawing.Point(81, 35);
            this.boxShrink.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.boxShrink.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.boxShrink.Name = "boxShrink";
            this.boxShrink.Size = new System.Drawing.Size(68, 20);
            this.boxShrink.TabIndex = 3;
            this.boxShrink.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // boxExpand
            // 
            this.boxExpand.BackColor = System.Drawing.Color.White;
            this.boxExpand.DecimalPlaces = 2;
            this.boxExpand.Enabled = false;
            this.boxExpand.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.boxExpand.Location = new System.Drawing.Point(81, 103);
            this.boxExpand.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.boxExpand.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.boxExpand.Name = "boxExpand";
            this.boxExpand.Size = new System.Drawing.Size(68, 20);
            this.boxExpand.TabIndex = 5;
            this.boxExpand.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelExpand
            // 
            this.labelExpand.AutoSize = true;
            this.labelExpand.Enabled = false;
            this.labelExpand.Location = new System.Drawing.Point(12, 105);
            this.labelExpand.Name = "labelExpand";
            this.labelExpand.Size = new System.Drawing.Size(67, 13);
            this.labelExpand.TabIndex = 4;
            this.labelExpand.Text = "Load Factor:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(74, 143);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(164, 179);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.boxExpand);
            this.Controls.Add(this.labelExpand);
            this.Controls.Add(this.boxShrink);
            this.Controls.Add(this.labelShrink);
            this.Controls.Add(this.checkExpand);
            this.Controls.Add(this.checkShrink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.boxShrink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxExpand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkShrink;
        private System.Windows.Forms.CheckBox checkExpand;
        private System.Windows.Forms.Label labelShrink;
        private System.Windows.Forms.NumericUpDown boxShrink;
        private System.Windows.Forms.NumericUpDown boxExpand;
        private System.Windows.Forms.Label labelExpand;
        private System.Windows.Forms.Button buttonConfirm;
    }
}