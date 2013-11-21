namespace GrabNDrop
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.pBottom = new System.Windows.Forms.Panel();
            this.cbOpenTempFolder = new System.Windows.Forms.CheckBox();
            this.cbDeleteFileAfterClosing = new System.Windows.Forms.CheckBox();
            this.lFileName = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.pTop = new System.Windows.Forms.Panel();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPencil = new System.Windows.Forms.ToolStripButton();
            this.tsbRubber = new System.Windows.Forms.ToolStripButton();
            this.tsbChooseColor = new System.Windows.Forms.ToolStripButton();
            this.tsbScaleToHundred = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.bSendMail = new System.Windows.Forms.Button();
            this.pBottom.SuspendLayout();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.bSendMail);
            this.pBottom.Controls.Add(this.cbOpenTempFolder);
            this.pBottom.Controls.Add(this.cbDeleteFileAfterClosing);
            this.pBottom.Controls.Add(this.lFileName);
            this.pBottom.Controls.Add(this.bCancel);
            this.pBottom.Controls.Add(this.tbFileName);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 298);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(427, 89);
            this.pBottom.TabIndex = 1;
            // 
            // cbOpenTempFolder
            // 
            this.cbOpenTempFolder.AutoSize = true;
            this.cbOpenTempFolder.Enabled = false;
            this.cbOpenTempFolder.Location = new System.Drawing.Point(88, 63);
            this.cbOpenTempFolder.Name = "cbOpenTempFolder";
            this.cbOpenTempFolder.Size = new System.Drawing.Size(174, 17);
            this.cbOpenTempFolder.TabIndex = 5;
            this.cbOpenTempFolder.Text = "&Open Temp Folder after closing";
            this.cbOpenTempFolder.UseVisualStyleBackColor = true;
            // 
            // cbDeleteFileAfterClosing
            // 
            this.cbDeleteFileAfterClosing.AutoSize = true;
            this.cbDeleteFileAfterClosing.Checked = true;
            this.cbDeleteFileAfterClosing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeleteFileAfterClosing.Location = new System.Drawing.Point(88, 42);
            this.cbDeleteFileAfterClosing.Name = "cbDeleteFileAfterClosing";
            this.cbDeleteFileAfterClosing.Size = new System.Drawing.Size(240, 17);
            this.cbDeleteFileAfterClosing.TabIndex = 4;
            this.cbDeleteFileAfterClosing.Text = "&Delete temporary file after closing this window";
            this.cbDeleteFileAfterClosing.UseVisualStyleBackColor = true;
            this.cbDeleteFileAfterClosing.CheckedChanged += new System.EventHandler(this.cbDeleteFileAfterClosing_CheckedChanged);
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFileName.Location = new System.Drawing.Point(12, 13);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(70, 18);
            this.lFileName.TabIndex = 3;
            this.lFileName.Text = "Filename:";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(331, 42);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(84, 38);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Done";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileName.Location = new System.Drawing.Point(88, 10);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(229, 26);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Enter += new System.EventHandler(this.tbFileName_Enter);
            this.tbFileName.Leave += new System.EventHandler(this.tbFileName_Leave);
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.pbPreview);
            this.pTop.Controls.Add(this.toolStrip1);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(427, 298);
            this.pTop.TabIndex = 2;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.Black;
            this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbPreview.InitialImage")));
            this.pbPreview.Location = new System.Drawing.Point(0, 25);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(427, 273);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.WaitOnLoad = true;
            this.pbPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPreview_MouseDown);
            this.pbPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPreview_MouseMove);
            this.pbPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPreview_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPencil,
            this.tsbRubber,
            this.tsbChooseColor,
            this.tsbScaleToHundred});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(427, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPencil
            // 
            this.tsbPencil.CheckOnClick = true;
            this.tsbPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPencil.Image = ((System.Drawing.Image)(resources.GetObject("tsbPencil.Image")));
            this.tsbPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPencil.Name = "tsbPencil";
            this.tsbPencil.Size = new System.Drawing.Size(23, 22);
            this.tsbPencil.Text = "Paint into the shot";
            this.tsbPencil.ToolTipText = "Paint in the picture";
            this.tsbPencil.Click += new System.EventHandler(this.tsbPencil_Click);
            // 
            // tsbRubber
            // 
            this.tsbRubber.CheckOnClick = true;
            this.tsbRubber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRubber.Image = ((System.Drawing.Image)(resources.GetObject("tsbRubber.Image")));
            this.tsbRubber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRubber.Name = "tsbRubber";
            this.tsbRubber.Size = new System.Drawing.Size(23, 22);
            this.tsbRubber.Text = "toolStripButton3";
            this.tsbRubber.ToolTipText = "Erase Paintings";
            this.tsbRubber.Visible = false;
            this.tsbRubber.Click += new System.EventHandler(this.tsbRubber_Click);
            // 
            // tsbChooseColor
            // 
            this.tsbChooseColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbChooseColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbChooseColor.Image")));
            this.tsbChooseColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChooseColor.Name = "tsbChooseColor";
            this.tsbChooseColor.Size = new System.Drawing.Size(23, 22);
            this.tsbChooseColor.Text = "Choose Painting Color";
            this.tsbChooseColor.ToolTipText = "Choose painting color";
            this.tsbChooseColor.Click += new System.EventHandler(this.tsbChooseColor_Click);
            // 
            // tsbScaleToHundred
            // 
            this.tsbScaleToHundred.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbScaleToHundred.Image = ((System.Drawing.Image)(resources.GetObject("tsbScaleToHundred.Image")));
            this.tsbScaleToHundred.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScaleToHundred.Name = "tsbScaleToHundred";
            this.tsbScaleToHundred.Size = new System.Drawing.Size(23, 22);
            this.tsbScaleToHundred.Text = "Scale to 100%";
            this.tsbScaleToHundred.Click += new System.EventHandler(this.tsbScaleToHundred_Click);
            // 
            // bSendMail
            // 
            this.bSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSendMail.Location = new System.Drawing.Point(331, 10);
            this.bSendMail.Name = "bSendMail";
            this.bSendMail.Size = new System.Drawing.Size(84, 26);
            this.bSendMail.TabIndex = 6;
            this.bSendMail.Text = "Email";
            this.bSendMail.UseVisualStyleBackColor = true;
            this.bSendMail.Click += new System.EventHandler(this.bSendMail_Click);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 387);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.pBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 250);
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview: Drag the Picture to your Application";
            this.Activated += new System.EventHandler(this.Preview_Activated);
            this.Deactivate += new System.EventHandler(this.Preview_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preview_FormClosing);
            this.Load += new System.EventHandler(this.Preview_Load);
            this.SizeChanged += new System.EventHandler(this.Preview_SizeChanged);
            this.pBottom.ResumeLayout(false);
            this.pBottom.PerformLayout();
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.CheckBox cbDeleteFileAfterClosing;
        private System.Windows.Forms.CheckBox cbOpenTempFolder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPencil;
        private System.Windows.Forms.ToolStripButton tsbRubber;
        private System.Windows.Forms.ToolStripButton tsbChooseColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripButton tsbScaleToHundred;
        private System.Windows.Forms.Button bSendMail;
    }
}