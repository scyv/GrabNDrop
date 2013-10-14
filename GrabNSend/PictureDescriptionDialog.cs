using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace GrabNDrop
{
    public partial class PictureDescriptionDialog : Form
    {

        private UploadInfo uploadInfo;
        public UploadInfo UploadInfo { set { uploadInfo = value; } }

        public PictureDescriptionDialog()
        {
            InitializeComponent();
        }

        private void bUpload_Click(object sender, EventArgs e)
        {
            pbUpload.Value = 0;
            pbUpload.Style = ProgressBarStyle.Continuous;
            tbDescription.Enabled = false;
            bUpload.Enabled = false;


            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("description", tbDescription.Text);
            uploadInfo.AdditionalData = nvc;

            bwUploader.RunWorkerAsync(uploadInfo);
        }

        public static void HttpUploadFile(BackgroundWorker bw, DoWorkEventArgs evt)
        {
            UploadInfo ui = (UploadInfo)evt.Argument;
            bw.ReportProgress(5);
            //System.Diagnostics.Debug.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(ui.Url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in ui.AdditionalData.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, ui.AdditionalData[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
                
            }
            bw.ReportProgress(10);
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            bw.ReportProgress(12);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, ui.ParamName, ui.File, ui.ContentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            bw.ReportProgress(15);

            FileStream fileStream = new FileStream(ui.File, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            FileInfo fi = new FileInfo(ui.File);
            double step = (double)80 / fi.Length;
            int currentProgress= 10;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                bw.ReportProgress(currentProgress);
                currentProgress += (int)Math.Round(step * bytesRead);
                rs.Write(buffer, 0, bytesRead);
                if (bw.CancellationPending)
                {
                    return;
                }

            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                //System.Diagnostics.Debug.WriteLine(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
                bw.ReportProgress(100);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Could not upload the file " + file + " to " + url + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                evt.Result = "Could not upload the file " + ui.File + " to " + ui.Url + "\n" + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error uploading file" + ex.Message);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            bw.ReportProgress(100);
            evt.Result = null;
        }

        private void bwUploader_DoWork(object sender, DoWorkEventArgs e)
        {

            UploadInfo ui = (UploadInfo)e.Argument;
            HttpUploadFile(bwUploader, e);

        }

        private void bwUploader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > pbUpload.Maximum)
            {
                pbUpload.Value = pbUpload.Maximum;
                pbUpload.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                pbUpload.Style = ProgressBarStyle.Continuous;
                pbUpload.Value = e.ProgressPercentage;
            }
        }

        private void bwUploader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                if (!e.Cancelled)
                {
                    MessageBox.Show("Upload was successful", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            MessageBox.Show(e.Result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tbDescription.Enabled = true;
            bUpload.Enabled = true;
        }

    }
}
