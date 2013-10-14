using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace GrabNDrop
{
    public partial class Preview : Form
    {

        private string filePath = "";
        private MiniPreview miniPreview;
        
        private Graphics pbGraphics;
        Pen pen = new Pen(Color.Red);
        int previousPointX = -1;
        int previousPointY = -1;
        int pointCount = 0;

        private Dictionary<string, string> settings;
        public Dictionary<string, string> Settings { get { return settings; } set { settings = value; } }


        int[] pointsX = new int[Screen.PrimaryScreen.Bounds.Height * Screen.PrimaryScreen.Bounds.Width];
        int[] pointsY = new int[Screen.PrimaryScreen.Bounds.Height * Screen.PrimaryScreen.Bounds.Width];
        


        public bool DeleteFileOnClosing { get { return this.cbDeleteFileAfterClosing.Checked; } }
        public bool OpenTempFolderOnClosing { get { return this.cbOpenTempFolder.Checked && this.cbOpenTempFolder.Enabled; } }

        private void SetTBFileName()
        {
            this.tbFileName.Text = System.IO.Path.GetFileNameWithoutExtension(this.filePath);
            if (miniPreview != null)
            {
                miniPreview.FilePath = this.filePath;
            }
        }

        private string GetTBFileName()
        {
            return System.IO.Path.GetDirectoryName(this.filePath) + "\\" + this.tbFileName.Text + "." + settings["type"].ToLower();
        }

        public Preview()
        {
            InitializeComponent();

            pen.Width = 3;
        }

        public void SetPicture(Image img)
        {
            pbPreview.Image = img;
            this.Text = "Preview: Drag the Picture to your Application";
        }
        public void SetPictureFile(string filePath)
        {
            this.filePath = filePath;
            if (!this.filePath.ToLower().Equals(this.GetTBFileName().ToLower()))
            {
                this.SetTBFileName();
            }
        }

        public string GetFileName()
        {
            return GetTBFileName();
        }

        private void pbPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (tsbPencil.Checked)
            {
                pbGraphics = pbPreview.CreateGraphics();
                previousPointX = e.Location.X;
                previousPointY = e.Location.Y;
                addPoint(e.Location);
            }
            else if (tsbRubber.Checked)
            {
            }
            else
            {
                tbFileName_Leave(sender, null);
                DataObject data = new DataObject(DataFormats.FileDrop, new string[] { filePath });
                DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        private void addPoint(Point point)
        {
            pointsX[pointCount] = point.X;
            pointsY[pointCount] = point.Y;
            pointCount++;
        }

        private float getZoomRatio()
        {
            Size imageSize = pbPreview.Image.Size;

            float ratio = (float)imageSize.Width / imageSize.Height;


            if (pbPreview.Height < pbPreview.Width / ratio)
            {
                return (float)pbPreview.Height / imageSize.Height;
            }
            else
            {
                return (float)pbPreview.Width / imageSize.Width;
            }

        }

        private void tbFileName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.filePath.CompareTo(this.GetTBFileName()) != 0)
                {
                    System.IO.File.Move(this.filePath, this.GetTBFileName());
                    this.SetPictureFile(this.GetTBFileName());
                }
            }
            catch(Exception ex)
            {
                this.SetTBFileName();
                MessageBox.Show("Error during file rename. Try another name or keep the proposed one.\nLocalized error message:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbFileName_Enter(object sender, EventArgs e)
        {
            this.tbFileName.Select(0, this.tbFileName.Text.Length);
        }

        private void Preview_SizeChanged(object sender, EventArgs e)
        {
            this.Text = "Preview: Drag the Picture to your Application (" + Math.Floor(getZoomRatio() * 100) + "%)";
        }

        private void Preview_Activated(object sender, EventArgs e)
        {
            if (miniPreview != null)
            {
                miniPreview.PreventParentClosing = true;
                miniPreview.Close();
                miniPreview = null;
            }
        }

        private void Preview_Deactivate(object sender, EventArgs e)
        {
            tbFileName_Leave(sender, e);
            miniPreview = new MiniPreview();
            miniPreview.Location = new Point(this.Location.X + this.Width - miniPreview.Width, this.Location.Y);
            miniPreview.FilePath = this.filePath;
            miniPreview.PreventParentClosing = false;
            miniPreview.PreviewParent = this;
            miniPreview.Show();
        }
    
        internal void Clean()
        {
            if (miniPreview != null)
            {
                miniPreview.PreventParentClosing = true;
                miniPreview.Close();
                miniPreview = null;
            }
        }

        private void cbDeleteFileAfterClosing_CheckedChanged(object sender, EventArgs e)
        {
            cbOpenTempFolder.Enabled = !cbDeleteFileAfterClosing.Checked;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }

        private void tsbChooseColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pen.Color;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              //  tsbPencil.BackColor = colorDialog.Color;
                pen.Color = colorDialog.Color;
                if (!tsbPencil.Checked)
                {
                    tsbPencil.Checked = true;
                    tsbPencil_Click(sender, e);
                }
            }
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            //tsbPencil.BackColor = pen.Color;
        }

        private void tsbCurrentColor_Click(object sender, EventArgs e)
        {
            tsbChooseColor_Click(sender, e);
        }

        private void tsbPencil_Click(object sender, EventArgs e)
        {
            if (tsbRubber.Checked)
            {
                tsbRubber.Checked = false;
            }
            if (tsbPencil.Checked)
            {
                pbPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            }
            else
            {
                pbPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void tsbRubber_Click(object sender, EventArgs e)
        {
            if (tsbPencil.Checked)
            {
                tsbPencil.Checked = false;
            }
        }

        private void tsbScaleToHundred_Click(object sender, EventArgs e)
        {

            //var dbPath = System.IO.Path.Combine(
            //        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dropbox\\host.db");

            //var dbBase64Text = Convert.FromBase64String(System.IO.File.ReadAllText(dbPath));

            //var folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);

            //System.Diagnostics.Debug.WriteLine(folderPath);

            Size imageSize = pbPreview.Image.Size;

            int newWidth = imageSize.Width + Width-pbPreview.Width;
            int newHeight = imageSize.Height + Height - pbPreview.Height;
            if (newHeight >= Screen.PrimaryScreen.WorkingArea.Height)
            {
                newHeight = Screen.PrimaryScreen.WorkingArea.Height;
            }

            if (newWidth >= Screen.PrimaryScreen.WorkingArea.Width)
            {
                newWidth = Screen.PrimaryScreen.WorkingArea.Width;
            }
            if (newHeight <= MinimumSize.Height)
            {
                newHeight = MinimumSize.Height;
            }
            if (newWidth <= MinimumSize.Width)
            {
                newWidth = MinimumSize.Width;
            }
            CenterToScreen();
            
            Left = Left - (int)Math.Round(((double)newWidth - Width) / 2);
            Top = Top - (int)Math.Round(((double)newHeight - Height) / 2);
            Width = newWidth;
            Height = newHeight;
        }

        private void pbPreview_MouseUp(object sender, MouseEventArgs e)
        {
            previousPointX = -1;
            previousPointY = -1;
            if (tsbPencil.Checked)
            {
                int factor = pointCount < 10 ? 1 : pointCount < 50 ? 3 : 5;
                PointF[] points = new PointF[pointCount/factor];
                if (points.Length > 1)
                {
                    float zoomRatio = getZoomRatio();
                    float offsetX = ((float)pbPreview.Width - (float)pbPreview.Image.Size.Width * zoomRatio) / 2;
                    float offsetY = ((float)pbPreview.Height - (float)pbPreview.Image.Size.Height * zoomRatio) / 2;
                    for (int i = 0; i < pointCount / factor; i++)
                    {
                        points[i] = new PointF((float)pointsX[i * factor] / zoomRatio - (offsetX > 0 ? offsetX / zoomRatio : 0), (float)pointsY[i * factor] / zoomRatio - (offsetY > 0 ? offsetY / zoomRatio : 0));
                    }

                    // always take the last point
                    points[points.Length - 1] = new PointF((float)pointsX[pointCount - 1] / zoomRatio - (offsetX > 0 ? offsetX / zoomRatio : 0), (float)pointsY[pointCount - 1] / zoomRatio - (offsetY > 0 ? offsetY / zoomRatio : 0));

                    pbGraphics.Dispose();
                    Graphics g = Graphics.FromImage(pbPreview.Image);
                    
                    g.DrawCurve(pen, points);

                    pbPreview.Image.Save(this.filePath);
                    g.Dispose();

                    pbPreview.Invalidate();

                }
                pointCount = 0;

            }
        }

        private void pbPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (tsbPencil.Checked && previousPointX > -1)
            {
               pbGraphics.DrawLine(pen, previousPointX, previousPointY, e.Location.X, e.Location.Y);
                previousPointX = e.Location.X;
                previousPointY = e.Location.Y;
                addPoint(e.Location);
            }
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {
            pbPreview.Image.Dispose();
            pen.Dispose();
            pointsX = null;
            pointsY = null;
        }

        private void bUpload_Click(object sender, EventArgs e)
        {
            //PictureDescriptionDialog pdd = new PictureDescriptionDialog();

            //UploadInfo uploadInfo = new UploadInfo();
            //uploadInfo.File = this.filePath;
            //uploadInfo.Url = "";
            //uploadInfo.ContentType = "image/jpeg";
            //uploadInfo.ParamName = "picture";

            //pdd.UploadInfo = uploadInfo;
            //if (pdd.ShowDialog(this) != System.Windows.Forms.DialogResult.Cancel)
            //{
            //    this.Close();
            //}
        }


    }
}

