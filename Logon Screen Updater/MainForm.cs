using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace Logon_Screen_Updater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region Global Variables
        RegistryKey regKey = null;
        string filename = string.Empty;
        int ScreenWidth = 0;
        int ScreenHeight = 0;
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + @"\GoogleSearchAPI.dll"))
            {
                File.WriteAllBytes(Application.StartupPath + @"\GoogleSearchAPI.dll", Properties.Resources.GoogleSearchAPI);
            }
            if (!File.Exists(Application.StartupPath + @"\Newtonsoft.Json.dll"))
            {
                File.WriteAllBytes(Application.StartupPath + @"\Newtonsoft.Json.dll", Properties.Resources.Newtonsoft_Json);
            }
            #region set status
            if (Environment.Is64BitOperatingSystem)
            {
                regKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                regKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background",true);

                object result = regKey.GetValue("OEMBackground");
                if (Convert.ToInt32(result) == 0)
                {
                    MessageBox.Show("Before you update the boot screen please enable the customization by going to: Tools-->Enable Custom Background"
                        , "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                regKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                regKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background",true);

                object result = regKey.GetValue("OEMBackground");
                if(Convert.ToInt32(result) == 0)
                {
                    MessageBox.Show("Before you update the boot screen please enable the customization but going to, Tools-->Enable Custom Background"
                       , "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            try
            {
                string workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "system32");
                if (Environment.Is64BitOperatingSystem)
                {
                    workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "sysnative");
                }
                string destination = workingPath + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                picBoxBackground.ImageLocation = destination;
            }
            catch(Exception)
            {
                
            }

            ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void enableCustomBackgrounfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regKey.SetValue("OEMBackground", 1, RegistryValueKind.DWord);
            string workingPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            if (!Directory.Exists(Path.Combine(workingPath + @"\System32\oobe\info\backgrounds")))
            {
                Directory.CreateDirectory(Path.Combine(workingPath + @"\System32\oobe\info\backgrounds"));
            }
        }

        private void disableCustomBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regKey.SetValue("OEMBackground", 0, RegistryValueKind.DWord);
        }

        private void setRandomScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(ofdSelectBackground.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = ofdSelectBackground.FileName;
                FileInfo f = new FileInfo(filename);
                long size = f.Length;
                if (size > 245000)
                {
                    if (MessageBox.Show("Your selected image is bigger than the allowed size, the image could be resized or you can choose another image.\n" +
                     "Would you like to a resized copy to be created?",
                         "Error",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                    {
                        filename = SaveJpeg(filename.Insert(filename.LastIndexOf('.'), "_New"), Image.FromFile(filename), CalculateQuality(size));
                    }
                    else
                    {
                        return;
                    }

                }
                Image img = Image.FromFile(filename);
                picBoxBackground.Image =img;
                if(img.Width != ScreenWidth && img.Height != ScreenHeight)
                {
                    MessageBox.Show(String.Format("It's is advisable that you use a picture that's the same size as your screen for optimum display. \n" +
                    "Your screen resolution is {0}x{1}", ScreenWidth, ScreenHeight),
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
        }

        private void btnSetBootScreen_Click(object sender, EventArgs e)
        {
            if (picBoxBackground.Image == null)
            {
                MessageBox.Show("Please select a picture to set as the boot screen image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "system32");
                if(Environment.Is64BitOperatingSystem)
                {
                    workingPath = Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "sysnative");
                }
                string destination = workingPath + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                File.Copy(filename, destination, true);
                MessageBox.Show("Boot screen updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("We could not update the boot screen at this moment, please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path">Path to which the image would be saved.</param> 
        // <param name="quality">An integer from 0 to 100, with 100 being the 
        /// highest quality</param> 
        public static string SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");


            // Encoder parameter for image quality 
            EncoderParameter qualityParam =
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // Jpeg image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
            return path;

        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        } 

        private int CalculateQuality(long size)
        {
            long diff = size - 245000;
            double diffPerc = (((double)diff / (double)size) * 100);
            int percent = (100 - Convert.ToInt32(diffPerc));
            return Convert.ToInt32(diffPerc);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void onlineImageSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnlineSearchForm online = new OnlineSearchForm();
            online.ShowDialog();  
        }

        private void lblPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PreviewForm preview = new PreviewForm(picBoxBackground.Image);
            preview.ShowDialog();
        }

        public static void CopyStream(Stream input, Stream output)
        {
            // Insert null checking here for production
            byte[] buffer = new byte[8192];

            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
        
    }
}
