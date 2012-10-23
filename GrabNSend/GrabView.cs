//#define BRANDING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace GrabNDrop
{
    public partial class GrabView : Form
    {
        private Point startPoint;
        
        private Point startMoveEventPoint;

        private Point leftTopPoint;
        private Point rightBottomPoint;
        private Panel spanPanel;
        private bool grabbing = false;

        private bool east = false;
        private bool west = false;
        private bool north = false;
        private bool south = false;
        private bool resizeSpanPanel = false;

        private Bitmap grabbedImage;

        private Dictionary<string, string> settings;
        public Dictionary<string, string> Settings { get { return settings; } set { settings = value; } }

        private string filePath;

        private Point oldLocation = new Point(-1,-1);

        public GrabView()
        {
            InitializeComponent();

            spanPanel = new Panel();
            spanPanel.ForeColor = Color.Red;
            spanPanel.Bounds = new Rectangle(0, 0, 0, 0);
            spanPanel.BorderStyle = BorderStyle.FixedSingle;
            spanPanel.BackColor = Color.Yellow;

            spanPanel.MouseMove += new MouseEventHandler(SpanPanel_MouseMove);
            spanPanel.MouseDown += new MouseEventHandler(SpanPanel_MouseDown);
            spanPanel.MouseUp += new MouseEventHandler(SpanPanel_MouseUp);

            this.Controls.Add(spanPanel);

        }

        private void SpanPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!resizeSpanPanel)
            {
                resizeSpanPanel = true;
                if (!south && !north && !west && !east)
                {
                    startMoveEventPoint = e.Location;
                    spanPanel.Cursor = Cursors.SizeAll;
                }
            }
            
        }

        private void SpanPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (resizeSpanPanel)
            {
                resizeSpanPanel = false;
                spanPanel.Cursor = Cursors.Default;
                lSize.Text += ". Press RETURN to Grab!";
            }
        }

        private void SpanPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizeSpanPanel)
            {
                if (east)
                {
                    spanPanel.Width = e.X;
                }
                else if (south)
                {
                    spanPanel.Height = e.Y;
                }
                else if (west)
                {
                    spanPanel.Left += e.X;
                    spanPanel.Width -= e.X;
                }
                else if (north)
                {
                    spanPanel.Top += e.Y;
                    spanPanel.Height -= e.Y;
                }
                else
                {
                    int newLeft = spanPanel.Left + e.X - startMoveEventPoint.X;
                    int newTop = spanPanel.Top + e.Y - startMoveEventPoint.Y;
                    if (newLeft < 0) newLeft = 0;
                    if (newTop < 0) newTop = 0;
                    if (newLeft > this.Width - spanPanel.Width) newLeft = this.Width - spanPanel.Width;
                    if (newTop > this.Height- spanPanel.Height) newTop= this.Height- spanPanel.Height;

                    spanPanel.Left = newLeft;
                    spanPanel.Top = newTop;
                }
                updateValues();
                rightBottomPoint.X = spanPanel.Left + spanPanel.Width;
                rightBottomPoint.Y = spanPanel.Top + spanPanel.Height;
                leftTopPoint = spanPanel.Location;
            }
            else
            {
                west = false;
                east = false;
                north = false;
                south = false;

                int tolerance = 8;

                if (e.X > spanPanel.Width - tolerance)
                {
                    east = true;
                }
                if (e.X < tolerance)
                {
                    west = true;
                }
                if (e.Y < tolerance)
                {
                    north = true;
                }
                if (e.Y > spanPanel.Height - tolerance)
                {
                    south = true;
                }

                if (north || south)
                {
                    spanPanel.Cursor = Cursors.SizeNS;
                }
                else if (west || east)
                {
                    spanPanel.Cursor = Cursors.SizeWE;
                }
                else
                {
                    spanPanel.Cursor = Cursors.Default;
                }
            }
        }

        private void GrabView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                finished();
            }
        }

        private void GrabView_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            lSize.Top = e.Y < 20 ? e.Y + 5 : e.Y - 15;
            lSize.Left = e.X;
            grabbing = true;
        }

        private void GrabView_MouseUp(object sender, MouseEventArgs e)
        {
            grabbing = false;
            if (bool.Parse(settings["afterGrabCorrection"])) {
                lSize.Text +=". Press RETURN to Grab!";
            } else {
                finished();
            }
        }

        private void GrabView_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbing)
            {
                if (oldLocation.X != e.X || oldLocation.Y != e.Y)
                {

                    if (startPoint.X < e.X)
                    {
                        if (startPoint.Y < e.Y)
                        {
                            rightBottomPoint = e.Location;
                            leftTopPoint = startPoint;
                        }
                        else
                        {
                            rightBottomPoint.X = e.X;
                            rightBottomPoint.Y = startPoint.Y;
                            leftTopPoint.X = startPoint.X;
                            leftTopPoint.Y = e.Y;
                        }
                    }
                    else
                    {
                        if (startPoint.Y < e.Y)
                        {
                            rightBottomPoint.X = startPoint.X;
                            rightBottomPoint.Y = e.Y;
                            leftTopPoint.X = e.X;
                            leftTopPoint.Y = startPoint.Y;
                        }
                        else
                        {
                            rightBottomPoint = startPoint;
                            leftTopPoint = e.Location;
                        }
                    }
                    spanPanel.Location = leftTopPoint;
                    spanPanel.Height = rightBottomPoint.Y - leftTopPoint.Y;
                    spanPanel.Width = rightBottomPoint.X - leftTopPoint.X;
                    updateValues();
                    oldLocation = e.Location;
                }

            }
        }

        private void updateValues()
        {
            lSize.Top = spanPanel.Location.Y < 20 ? spanPanel.Location.Y + 5 : spanPanel.Location.Y - 15;
            lSize.Left = spanPanel.Location.X;
            lSize.Text = spanPanel.Width + " x " + spanPanel.Height;
        }

        private void finished()
        {
            //if (grabbing)
            //{
            //    grabbing = false;

                try
                {
                    if (grabbedImage != null)
                    {
                        grabbedImage.Dispose();
                    }

                    if (Grab())
                    {
                        this.DialogResult = DialogResult.OK;
                    }

                }
                catch (Exception ex)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.Close();
            //}
        }

        private bool Grab()
        {
            this.Visible = false;
            this.Refresh();
            if (rightBottomPoint.X - leftTopPoint.X <= 0 || rightBottomPoint.Y - leftTopPoint.Y <= 0)
            {
                return false;
            }
            System.Threading.Thread.Sleep(500);
            Rectangle r = new Rectangle(leftTopPoint, new Size(rightBottomPoint.X - leftTopPoint.X, rightBottomPoint.Y - leftTopPoint.Y));
            grabbedImage = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(grabbedImage);
            g.CopyFromScreen(r.X, r.Y, 0, 0, grabbedImage.Size);

            #if BRANDING
            // branding
            Font f = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Monospace), 8.0f, FontStyle.Italic);
            Brush transparentBrush = new SolidBrush(Color.FromArgb(80, 255, 0, 0));
            g.DrawString("Grabbed by GrabNDrop", f, transparentBrush, new PointF(0.0f, r.Height - f.GetHeight() - 5));
            #endif
            
            g.Dispose();
            this.Visible = true;
            this.filePath = System.IO.Path.GetTempPath() + settings["filePrefix"] + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + settings["type"].ToLower();

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, long.Parse(settings["quality"]));
            grabbedImage.Save(this.filePath, getEncoderInfo(settings["type"]), encoderParams);
            return true;
        }

        public Image GetGrabbedImage()
        {
            return grabbedImage;
        }

        public string GetGrabbedFilePath()
        {
            return filePath;
        }


        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].FilenameExtension.ToLower().Contains(mimeType.ToLower()))
                {
                    return codecs[i];
                }
            }
            return null;
        }

    }
}
