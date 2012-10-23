using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrabNDrop
{
    public partial class MiniPreview : Form
    {
        private String filePath = "";
        public String FilePath { get { return filePath; } set { this.filePath = value; this.pictureBox.ImageLocation = value; } }

        private Preview previewParent;
        public Preview PreviewParent { set { this.previewParent = value; } }
        
        private bool preventParentClosing = true;
        public bool PreventParentClosing { set { this.preventParentClosing = value; } }

        public MiniPreview()
        {
            InitializeComponent();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.FileDrop, new string[] { filePath });
            DoDragDrop(data, DragDropEffects.Copy);
        }

        private void MiniPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.previewParent != null && !preventParentClosing)
            {
                previewParent.Close();
            }
        }
    }
}
