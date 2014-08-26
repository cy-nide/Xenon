using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Logon_Screen_Updater
{
    public partial class WrapPanel : UserControl
    {
        public WrapPanel()
        {
            InitializeComponent();
            this.VerticalScroll.Enabled = true;
            this.VerticalScroll.Visible = true;
            this.VScroll = true;
            parentWidth = this.Size.Width;
            parentHeight = this.Size.Height;
            this.Resize += new EventHandler(WrapPanel_Resize);
        }

        void WrapPanel_Resize(object sender, EventArgs e)
        {
            parentWidth = this.Size.Width;
            parentHeight = this.Size.Height;
        }
        #region Global Variables
        int parentWidth = 0;
        int parentHeight = 0;
        int currentX = 0;
        int currentY = 0;
        PictureBox currPicBox = null;
        #endregion
        private void WrapPanel_ControlAdded(object sender, ControlEventArgs e)
        {
           
        }

        public void Add(string name ,int width, int height)
        {
            PictureBox con = new PictureBox();
            con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            con.SizeMode = PictureBoxSizeMode.StretchImage;
            con.LoadAsync(name);
            con.Parent = this;
            if (currentX >= parentWidth - 100)
            {
                currentX = 0;
                currentY += height + 10;
            }
            con.Location = new Point(currentX, currentY);
            con.Width = width;
            con.Height = height;
            con.ContextMenuStrip = contextMenu;
            con.Click += new EventHandler(con_Click);
            con.MouseUp += new MouseEventHandler(con_MouseUp);
            con.CreateControl();

            currentX += width + 10;
            
        }

        void con_MouseUp(object sender, MouseEventArgs e)
        {
           if(e.Button == System.Windows.Forms.MouseButtons.Right)
           {
               if (currPicBox != null)
               {
                   currPicBox.Invalidate();
               }
               currPicBox = (PictureBox)sender;
               ControlPaint.DrawBorder(currPicBox.CreateGraphics(), currPicBox.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
           }
        }

        void con_Click(object sender, EventArgs e)
        {
           
           if(currPicBox != null)
           {
               currPicBox.Invalidate();
           }
           currPicBox = (PictureBox)sender;
           ControlPaint.DrawBorder(currPicBox.CreateGraphics(), currPicBox.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currPicBox.Image.Save(Application.StartupPath + "_temp1.jpg");
            try
            {
                string workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "system32");
                if (Environment.Is64BitOperatingSystem)
                {
                    workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "sysnative");
                }
                string destination = workingPath + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                File.Copy(Application.StartupPath + @"\_temp1.jpg", destination, true);
                MessageBox.Show("Boot screen updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("We could not update the boot screen at this moment, please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void resetLocation()
        {
            currentX = 0;
            currentY = 0;
        }
    }
}
