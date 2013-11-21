using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace GrabNDrop
{

    public partial class Main : Form
    {
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
        private bool grabbing = false;

        private long quality = 100L;
        private string type = "png";
        private bool afterGrabCorrection = true;
        private bool hookPrintScreen = true;
        private string filePrefix = "Grabbed_";

        private String settingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GrabNDrop/settings.properties");

        public Main()
        {
            _hookID = SetHook(_proc, this);

            InitializeComponent();

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
            hookPrintScreen = bool.Parse(getSetting("hookPrintScreen", "true"));

            tsmiCapturePrintscreen.Checked = hookPrintScreen;
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

        private void bGrab_Click(object sender, EventArgs e)
        {
            Grab();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            this.Dispose();
        }

        private void Grab()
        {
            if (grabbing) {
                return;
            }
            grabbing = true;

            GrabView gv = new GrabView();
            gv.Settings = settings;
           
            if (gv.ShowDialog() == DialogResult.OK)
            {
                grabbing = false;
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
            grabbing = false;
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
                "(c)2013 Yves Schubert\nAll Rights Reserved.\n" +
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


        private void tsmiCapturePrintscreen_Click(object sender, EventArgs e)
        {
            hookPrintScreen = !hookPrintScreen;
            tsmiCapturePrintscreen.Checked = hookPrintScreen;
            saveSetting("hookPrintScreen", hookPrintScreen.ToString().ToLower());
        }

        #region PrintScreenHook

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_F1 = 0x70;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static Main _main;
        private static IntPtr SetHook(LowLevelKeyboardProc proc, Main main)
        {
            _main = main;
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0)
            {
                Keys number = (Keys)Marshal.ReadInt32(lParam);
                if (number == Keys.PrintScreen)
                {
                    if (_main.hookPrintScreen)
                    {
                        _main.Grab();
                    }
                }

            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion

    }
}
