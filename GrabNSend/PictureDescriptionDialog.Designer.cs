namespace GrabNDrop
{
    partial class PictureDescriptionDialog
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
            this.lDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bUpload = new System.Windows.Forms.Button();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.bCancel = new System.Windows.Forms.Button();
            this.bwUploader = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescription.Location = new System.Drawing.Point(12, 37);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(83, 18);
            this.lDescription.TabIndex = 5;
            this.lDescription.Text = "Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.Location = new System.Drawing.Point(101, 34);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(326, 26);
            this.tbDescription.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Please provide a description text for the picture";
            // 
            // bUpload
            // 
            this.bUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpload.Location = new System.Drawing.Point(221, 111);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(116, 37);
            this.bUpload.TabIndex = 7;
            this.bUpload.Text = "Start Upload";
            this.bUpload.UseVisualStyleBackColor = true;
            this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
            // 
            // pbUpload
            // 
            this.pbUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpload.Location = new System.Drawing.Point(15, 73);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(412, 23);
            this.pbUpload.TabIndex = 8;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(343, 111);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(80, 37);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bwUploader
            // 
            this.bwUploader.WorkerReportsProgress = true;
            this.bwUploader.WorkerSupportsCancellation = true;
            this.bwUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUploader_DoWork);
            this.bwUploader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwUploader_ProgressChanged);
            this.bwUploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwUploader_RunWorkerCompleted);
            // 
            // PictureDescriptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(439, 160);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.pbUpload);
            this.Controls.Add(this.bUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.tbDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PictureDescriptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picture Upload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.ProgressBar pbUpload;
        private System.Windows.Forms.Button bCancel;
        private System.ComponentModel.BackgroundWorker bwUploader;
    }
}