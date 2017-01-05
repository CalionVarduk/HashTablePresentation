namespace HashTablePresentation
{
    partial class ResizeForm
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
            this.boxSize = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxSize)).BeginInit();
            this.SuspendLayout();
            // 
            // boxSize
            // 
            this.boxSize.BackColor = System.Drawing.Color.White;
            this.boxSize.Location = new System.Drawing.Point(77, 12);
            this.boxSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.boxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxSize.Name = "boxSize";
            this.boxSize.Size = new System.Drawing.Size(76, 20);
            this.boxSize.TabIndex = 0;
            this.boxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(12, 14);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 1;
            this.labelSize.Text = "Size:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(77, 38);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(76, 23);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(165, 72);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.boxSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResizeForm";
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.boxSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown boxSize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonConfirm;
    }
}