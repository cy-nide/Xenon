namespace Logon_Screen_Updater
{
    partial class OnlineSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineSearchForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearchString = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.numberOfResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtResultCount = new System.Windows.Forms.ToolStripTextBox();
            this.wrapPanel1 = new Logon_Screen_Updater.WrapPanel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.txtSearchString,
            this.numberOfResultsToolStripMenuItem,
            this.txtResultCount});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(606, 31);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(65, 27);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // txtSearchString
            // 
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(100, 27);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // numberOfResultsToolStripMenuItem
            // 
            this.numberOfResultsToolStripMenuItem.Name = "numberOfResultsToolStripMenuItem";
            this.numberOfResultsToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.numberOfResultsToolStripMenuItem.Text = "Result Count";
            // 
            // txtResultCount
            // 
            this.txtResultCount.Name = "txtResultCount";
            this.txtResultCount.Size = new System.Drawing.Size(100, 27);
            // 
            // wrapPanel1
            // 
            this.wrapPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wrapPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrapPanel1.Location = new System.Drawing.Point(0, 31);
            this.wrapPanel1.Name = "wrapPanel1";
            this.wrapPanel1.Size = new System.Drawing.Size(606, 356);
            this.wrapPanel1.TabIndex = 2;
            // 
            // OnlineSearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 387);
            this.Controls.Add(this.wrapPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Online Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnlineSearchForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtSearchString;
        private System.Windows.Forms.Button btnSearch;
        private WrapPanel wrapPanel1;
        private System.Windows.Forms.ToolStripMenuItem numberOfResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtResultCount;
    }
}