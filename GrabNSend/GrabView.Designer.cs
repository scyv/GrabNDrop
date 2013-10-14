namespace GrabNDrop
{
    partial class GrabView
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
            this.lSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lSize
            // 
            this.lSize.AutoSize = true;
            this.lSize.BackColor = System.Drawing.Color.Black;
            this.lSize.ForeColor = System.Drawing.Color.White;
            this.lSize.Location = new System.Drawing.Point(12, 9);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(0, 13);
            this.lSize.TabIndex = 0;
            // 
            // GrabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lSize);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrabView";
            this.Opacity = 0.2D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrabView_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrabView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrabView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GrabView_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSize;

    }
}