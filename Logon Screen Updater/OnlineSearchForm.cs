using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Search;
using Google;
using Google.API.Search.Converters;
using System.IO;
using System.Net;

namespace Logon_Screen_Updater
{
    public partial class OnlineSearchForm : Form
    {
        public OnlineSearchForm()
        {
            InitializeComponent();
        }

        #region Global Variables


        #endregion

        private void OnlineSearchForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region Get Images
            int resultCount = 0;
            if (string.IsNullOrEmpty(txtSearchString.Text.TrimEnd()))
            {
                MessageBox.Show("Please enter a search criteria", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtResultCount.Text == null || txtResultCount.Text.Trim().Length == 0 || txtResultCount.Text.Trim() == "")
            {
                resultCount = 100;
            }
            else
                resultCount = Convert.ToInt32(txtResultCount.Text);
            String screenSize = Screen.PrimaryScreen.Bounds.Width.ToString() + "x" + Screen.PrimaryScreen.Bounds.Height.ToString();
            GimageSearchClient client = new GimageSearchClient("www.google.com");
            IList<IImageResult> results = client.Search(txtSearchString.Text.TrimEnd(), resultCount, "", screenSize, "colorized", "jpg", "jpg", "www.google.com");
            wrapPanel1.Controls.Clear();
            wrapPanel1.resetLocation();
            foreach (IImageResult image in results)
            {
                try
                {
                    wrapPanel1.Add(image.Url, 170, 140);
                }
                catch (WebException)
                {
                    continue;
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }
            #endregion
        }

    }
}
