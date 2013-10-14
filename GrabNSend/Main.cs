using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace GrabNDrop
{

    public partial class Main : Form
    {
        //[DllImport("user32.dll")]
        //public static extern bool RegisterHotKey(IntPtr hWnd,
        //  int id, int fsModifiers, int vlc);
        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        private const int FO_DELETE = 3;
        private const int FOF_ALLOWUNDO = 0x40;
        private const int FOF_NOCONFIRMATION = 0x0010;

        private Dictionary<string, string> settings;

        private bool resizeHookEnabled = false;

        private long quality = 100L;
        private string type = "png";
        private bool afterGrabCorrection = true;
        private string filePrefix = "Grabbed_";

        private String settingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GrabNDrop/settings.properties");

        public Main()
        {
            InitializeComponent();

            //RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 0, (int)Keys.PrintScreen);

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Hide();

           

            settings = new Dictionary<string, string>();
            if (System.IO.File.Exists(settingsFile))
            {
                foreach (var row in System.IO.File.ReadAllLines(settingsFile))
                {
                    string[] split = row.Split('=');
                    if (split.Length > 1)
                    {
                        settings.Add(split[0], split[1]);
                    }
                }
            }

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                string[] split = arg.Split('=');
                if (split.Length > 1)
                {
                    if (settings.ContainsKey(split[0]))
                    {
                        settings.Remove(split[0]);
                    }
                    settings.Add(split[0], split[1]);
                }
            }


            quality = long.Parse(getSetting("quality", "100"));
            type = getSetting("type", "PNG").ToUpper();
            afterGrabCorrection = bool.Parse(getSetting("afterGrabCorrection", "true"));
            filePrefix = getSetting("filePrefix", "Grabbed_");

            tsmiAllowBoxCorrection.Checked = afterGrabCorrection;

            if (type.Equals("JPG"))
            {
                tscbType.SelectedIndex = 1;
            }
            else
            {
                tscbType.SelectedIndex = 0;
                type = "PNG";
            }

            switch (quality)
            {
                case 100: tscbQualty.SelectedIndex = 0; break;
                case 80: tscbQualty.SelectedIndex = 1; break;
                case 50: tscbQualty.SelectedIndex = 2; break;
                default: tscbQualty.SelectedIndex = 0; quality = 100L; break;
            }

            saveSetting("quality", quality.ToString());
            saveSetting("type", type);
            saveSetting("afterGrabCorrection", afterGrabCorrection.ToString().ToLower());
            saveSetting("filePrefix", filePrefix);
        }

        private void saveSetting(string key, string value, bool create)
        {
            if (create || !settings.ContainsKey(key))
            {
                if (settings.ContainsKey(key)) { settings.Remove(key); }
                settings.Add(key, value);
                DirectoryInfo appDataDir = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GrabNDrop"));
                if (!appDataDir.Exists){
                    appDataDir.Create();
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(settingsFile);
                foreach (KeyValuePair<string, string> pair in settings)
                {
                    sw.WriteLine(pair.Key + "=" + pair.Value);
                }
                sw.Flush();
                sw.Close();
            }
        }
        private void saveSetting(string key, string value)
        {
            saveSetting(key, value, true);
        }
    
        private string getSetting(string key, string defaultValue) {
            string value;
            settings.TryGetValue(key, out value);
            if (value == null)
            {
                return defaultValue;
            }
            return value;
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0312)
        //    {
        //        Grab();
        //    }
        //    base.WndProc(ref m);
        //}

        private void bGrab_Click(object sender, EventArgs e)
        {
            Grab();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Grab()
        {
            GrabView gv = new GrabView();
            gv.Settings = settings;
            if (gv.ShowDialog() == DialogResult.OK)
            {
                Preview preview = new Preview();
                preview.Settings = settings;
                preview.SetPicture(gv.GetGrabbedImage());
                preview.SetPictureFile(gv.GetGrabbedFilePath());
                preview.ShowDialog();


                if (preview.DeleteFileOnClosing)
                {
                    try
                    {
                        System.IO.File.Delete(preview.GetFileName());

/*                        SHFILEOPSTRUCT fileop = new SHFILEOPSTRUCT();
                        fileop.wFunc = FO_DELETE;
                        fileop.pFrom = preview.GetFileName() + '\0' + '\0';
                        fileop.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;
                        int ret = SHFileOperation(ref fileop);
                        System.Diagnostics.Debug.WriteLine(ret);*/
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                        // ignore
                    }
                }

                if(preview.OpenTempFolderOnClosing) {
                    System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(preview.GetFileName()));
                }

                preview.Clean();
                gv.GetGrabbedImage().Dispose();
            }
        }

        private void grabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grab();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.notifyIcon.Visible = false;
            this.resizeHookEnabled = true;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.resizeHookEnabled && this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.notifyIcon.Visible = true;
               // this.Hide();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Grab();
        }

        private void bGrab_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GrabNDrop Version " + Application.ProductVersion + "\n" +
                "(c)2012 Yves Schubert\nAll Rights Reserved.\n" +
                "More information and current version at: http://www.scyv.de\n\nThe Program icons are under Copyright from Mark James (http://www.famfamfam.com/lab/icons/silk/)", "GrabNDrop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tscbQualty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbQualty.SelectedIndex == 0)
            {
                quality = 100L;
            }
            else if (tscbQualty.SelectedIndex == 1)
            {
                quality = 80L;
            }
            else
            {
                quality = 50L;
            }

            saveSetting("quality", quality.ToString());
        }

        private void tscbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbType.SelectedIndex == 0)
            {
                type = "png";
            }
            else
            {
                type = "jpg";
            }
            saveSetting("type", type);
        }

        private void tsmiAllowBoxCorrection_Click(object sender, EventArgs e)
        {
            afterGrabCorrection = !afterGrabCorrection;
            tsmiAllowBoxCorrection.Checked = afterGrabCorrection;
            saveSetting("afterGrabCorrection", afterGrabCorrection.ToString().ToLower());
        }

    }
}
