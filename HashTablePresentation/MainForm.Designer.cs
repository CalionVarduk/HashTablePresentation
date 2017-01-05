namespace HashTablePresentation
{
    partial class MainForm
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
            this.labelSpeed = new System.Windows.Forms.Label();
            this.boxSpeed = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelAnimation = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelQueuedTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelQueued = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.buttonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonResize = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBucketsTitle = new System.Windows.Forms.Label();
            this.labelBuckets = new System.Windows.Forms.Label();
            this.labelItems = new System.Windows.Forms.Label();
            this.labelItemsTitle = new System.Windows.Forms.Label();
            this.labelFactor = new System.Windows.Forms.Label();
            this.labelFactorTitle = new System.Windows.Forms.Label();
            this.checkPaused = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxSpeed)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.ForeColor = System.Drawing.Color.White;
            this.labelSpeed.Location = new System.Drawing.Point(12, 29);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(90, 13);
            this.labelSpeed.TabIndex = 2;
            this.labelSpeed.Text = "Animation Speed:";
            // 
            // boxSpeed
            // 
            this.boxSpeed.BackColor = System.Drawing.Color.White;
            this.boxSpeed.DecimalPlaces = 3;
            this.boxSpeed.ForeColor = System.Drawing.Color.Black;
            this.boxSpeed.Increment = new decimal(new int[] {
            125,
            0,
            0,
            196608});
            this.boxSpeed.Location = new System.Drawing.Point(108, 27);
            this.boxSpeed.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.boxSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.boxSpeed.Name = "boxSpeed";
            this.boxSpeed.Size = new System.Drawing.Size(61, 20);
            this.boxSpeed.TabIndex = 3;
            this.boxSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.boxSpeed.ValueChanged += new System.EventHandler(this.boxSpeed_ValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelAnimation,
            this.labelSpring,
            this.labelQueuedTitle,
            this.labelQueued});
            this.statusStrip.Location = new System.Drawing.Point(0, 331);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(588, 22);
            this.statusStrip.TabIndex = 5;
            // 
            // labelAnimation
            // 
            this.labelAnimation.ForeColor = System.Drawing.Color.White;
            this.labelAnimation.Name = "labelAnimation";
            this.labelAnimation.Size = new System.Drawing.Size(110, 17);
            this.labelAnimation.Text = "<animation string>";
            this.labelAnimation.Visible = false;
            // 
            // labelSpring
            // 
            this.labelSpring.ForeColor = System.Drawing.Color.White;
            this.labelSpring.Name = "labelSpring";
            this.labelSpring.Size = new System.Drawing.Size(444, 17);
            this.labelSpring.Spring = true;
            // 
            // labelQueuedTitle
            // 
            this.labelQueuedTitle.ForeColor = System.Drawing.Color.White;
            this.labelQueuedTitle.Name = "labelQueuedTitle";
            this.labelQueuedTitle.Size = new System.Drawing.Size(116, 17);
            this.labelQueuedTitle.Text = "Animations Queued:";
            // 
            // labelQueued
            // 
            this.labelQueued.ForeColor = System.Drawing.Color.White;
            this.labelQueued.Name = "labelQueued";
            this.labelQueued.Size = new System.Drawing.Size(13, 17);
            this.labelQueued.Text = "0";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove,
            this.buttonSearch,
            this.buttonResize,
            this.buttonSettings});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(588, 24);
            this.menuStrip.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(68, 20);
            this.buttonAdd.Text = "Add Item";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(89, 20);
            this.buttonRemove.Text = "Remove Item";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 20);
            this.buttonSearch.Text = "Search For Item";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonResize
            // 
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(51, 20);
            this.buttonResize.Text = "Resize";
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(61, 20);
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // labelBucketsTitle
            // 
            this.labelBucketsTitle.AutoSize = true;
            this.labelBucketsTitle.ForeColor = System.Drawing.Color.White;
            this.labelBucketsTitle.Location = new System.Drawing.Point(187, 29);
            this.labelBucketsTitle.Name = "labelBucketsTitle";
            this.labelBucketsTitle.Size = new System.Drawing.Size(49, 13);
            this.labelBucketsTitle.TabIndex = 7;
            this.labelBucketsTitle.Text = "Buckets:";
            // 
            // labelBuckets
            // 
            this.labelBuckets.AutoSize = true;
            this.labelBuckets.ForeColor = System.Drawing.Color.White;
            this.labelBuckets.Location = new System.Drawing.Point(234, 29);
            this.labelBuckets.Name = "labelBuckets";
            this.labelBuckets.Size = new System.Drawing.Size(19, 13);
            this.labelBuckets.TabIndex = 8;
            this.labelBuckets.Text = "10";
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.ForeColor = System.Drawing.Color.White;
            this.labelItems.Location = new System.Drawing.Point(301, 29);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(13, 13);
            this.labelItems.TabIndex = 10;
            this.labelItems.Text = "0";
            // 
            // labelItemsTitle
            // 
            this.labelItemsTitle.AutoSize = true;
            this.labelItemsTitle.ForeColor = System.Drawing.Color.White;
            this.labelItemsTitle.Location = new System.Drawing.Point(268, 29);
            this.labelItemsTitle.Name = "labelItemsTitle";
            this.labelItemsTitle.Size = new System.Drawing.Size(35, 13);
            this.labelItemsTitle.TabIndex = 9;
            this.labelItemsTitle.Text = "Items:";
            // 
            // labelFactor
            // 
            this.labelFactor.AutoSize = true;
            this.labelFactor.ForeColor = System.Drawing.Color.White;
            this.labelFactor.Location = new System.Drawing.Point(394, 29);
            this.labelFactor.Name = "labelFactor";
            this.labelFactor.Size = new System.Drawing.Size(34, 13);
            this.labelFactor.TabIndex = 12;
            this.labelFactor.Text = "0,000";
            // 
            // labelFactorTitle
            // 
            this.labelFactorTitle.AutoSize = true;
            this.labelFactorTitle.ForeColor = System.Drawing.Color.White;
            this.labelFactorTitle.Location = new System.Drawing.Point(329, 29);
            this.labelFactorTitle.Name = "labelFactorTitle";
            this.labelFactorTitle.Size = new System.Drawing.Size(67, 13);
            this.labelFactorTitle.TabIndex = 11;
            this.labelFactorTitle.Text = "Load Factor:";
            // 
            // checkPaused
            // 
            this.checkPaused.AutoSize = true;
            this.checkPaused.ForeColor = System.Drawing.Color.White;
            this.checkPaused.Location = new System.Drawing.Point(443, 28);
            this.checkPaused.Name = "checkPaused";
            this.checkPaused.Size = new System.Drawing.Size(62, 17);
            this.checkPaused.TabIndex = 13;
            this.checkPaused.Text = "Paused";
            this.checkPaused.UseVisualStyleBackColor = true;
            this.checkPaused.CheckedChanged += new System.EventHandler(this.checkPaused_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(588, 353);
            this.Controls.Add(this.checkPaused);
            this.Controls.Add(this.labelFactor);
            this.Controls.Add(this.labelFactorTitle);
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.labelItemsTitle);
            this.Controls.Add(this.labelBuckets);
            this.Controls.Add(this.labelBucketsTitle);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.boxSpeed);
            this.Controls.Add(this.labelSpeed);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Hash Table Presentation";
            ((System.ComponentModel.ISupportInitialize)(this.boxSpeed)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.NumericUpDown boxSpeed;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labelAnimation;
        private System.Windows.Forms.ToolStripStatusLabel labelSpring;
        private System.Windows.Forms.ToolStripStatusLabel labelQueuedTitle;
        private System.Windows.Forms.ToolStripStatusLabel labelQueued;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem buttonRemove;
        private System.Windows.Forms.ToolStripMenuItem buttonSearch;
        private System.Windows.Forms.ToolStripMenuItem buttonResize;
        private System.Windows.Forms.Label labelBucketsTitle;
        private System.Windows.Forms.Label labelBuckets;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.Label labelItemsTitle;
        private System.Windows.Forms.Label labelFactor;
        private System.Windows.Forms.Label labelFactorTitle;
        private System.Windows.Forms.ToolStripMenuItem buttonSettings;
        private System.Windows.Forms.CheckBox checkPaused;
    }
}

