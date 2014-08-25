using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logon_Screen_Updater
{
    public partial class PreviewForm : Form
    {
        public PreviewForm(Image _image)
        {
            InitializeComponent();
            prevImage = _image;
        }
        Image prevImage;
        private void PreviewForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = prevImage;
           // txtPassword.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);

        }

        private void PreviewForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PreviewForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
