namespace GrabNDrop
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.bGrab = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.tbSMTPServer = new System.Windows.Forms.TextBox();
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscbQualty = new System.Windows.Forms.ToolStripComboBox();
            this.tscbType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tsmiAllowBoxCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // bGrab
            // 
            this.bGrab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bGrab.Location = new System.Drawing.Point(263, 248);
            this.bGrab.Name = "bGrab";
            this.bGrab.Size = new System.Drawing.Size(75, 23);
            this.bGrab.TabIndex = 0;
            this.bGrab.Text = "Grab";
            this.bGrab.UseVisualStyleBackColor = true;
            this.bGrab.VisibleChanged += new System.EventHandler(this.bGrab_VisibleChanged);
            this.bGrab.Click += new System.EventHandler(this.bGrab_Click);
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Location = new System.Drawing.Point(344, 248);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 1;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tbSMTPServer
            // 
            this.tbSMTPServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSMTPServer.Location = new System.Drawing.Point(52, 12);
            this.tbSMTPServer.Name = "tbSMTPServer";
            this.tbSMTPServer.Size = new System.Drawing.Size(367, 20);
            this.tbSMTPServer.TabIndex = 2;
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.toolStripSeparator2,
            this.tsmiAllowBoxCorrection,
            this.tscbQualty,
            this.tscbType,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.cmTray.Name = "cmTray";
            this.cmTray.Size = new System.Drawing.Size(191, 180);
            // 
            // grabToolStripMenuItem
            // 
            this.grabToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grabToolStripMenuItem.Name = "grabToolStripMenuItem";
            this.grabToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.grabToolStripMenuItem.Text = "Grab!";
            this.grabToolStripMenuItem.Click += new System.EventHandler(this.grabToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.infoToolStripMenuItem.Text = "&Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // tscbQualty
            // 
            this.tscbQualty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbQualty.Items.AddRange(new object[] {
            "High Quality",
            "Medium Quality",
            "Low Quality"});
            this.tscbQualty.Name = "tscbQualty";
            this.tscbQualty.Size = new System.Drawing.Size(121, 23);
            this.tscbQualty.ToolTipText = "Quality";
            this.tscbQualty.SelectedIndexChanged += new System.EventHandler(this.tscbQualty_SelectedIndexChanged);
            // 
            // tscbType
            // 
            this.tscbType.AutoCompleteCustomSource.AddRange(new string[] {
            "PNG",
            "JPEG"});
            this.tscbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbType.Items.AddRange(new object[] {
            "PNG",
            "JPEG"});
            this.tscbType.Name = "tscbType";
            this.tscbType.Size = new System.Drawing.Size(121, 23);
            this.tscbType.ToolTipText = "Filetype";
            this.tscbType.SelectedIndexChanged += new System.EventHandler(this.tscbType_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "GrabNDrop";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // tsmiAllowBoxCorrection
            // 
            this.tsmiAllowBoxCorrection.Name = "tsmiAllowBoxCorrection";
            this.tsmiAllowBoxCorrection.Size = new System.Drawing.Size(190, 22);
            this.tsmiAllowBoxCorrection.Text = "Allow Box Corrections";
            this.tsmiAllowBoxCorrection.Click += new System.EventHandler(this.tsmiAllowBoxCorrection_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 283);
            this.Controls.Add(this.tbSMTPServer);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bGrab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrabNDrop";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.cmTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGrab;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.TextBox tbSMTPServer;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem grabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tscbQualty;
        private System.Windows.Forms.ToolStripComboBox tscbType;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllowBoxCorrection;
    }
}

