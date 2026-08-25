namespace Gumani_AAPD7112w_POE
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localEventsAndAnnouncementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceRequestStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(692, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the municipalitity of Tshawne Pretoria";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectMenuToolStripMenuItem
            // 
            this.selectMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportIssueToolStripMenuItem,
            this.localEventsAndAnnouncementsToolStripMenuItem,
            this.serviceRequestStatusToolStripMenuItem});
            this.selectMenuToolStripMenuItem.Name = "selectMenuToolStripMenuItem";
            this.selectMenuToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.selectMenuToolStripMenuItem.Text = "Select Menu";
            this.selectMenuToolStripMenuItem.Click += new System.EventHandler(this.selectMenuToolStripMenuItem_Click);
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.reportIssueToolStripMenuItem.Text = "Report Issue";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click);
            // 
            // localEventsAndAnnouncementsToolStripMenuItem
            // 
            this.localEventsAndAnnouncementsToolStripMenuItem.Name = "localEventsAndAnnouncementsToolStripMenuItem";
            this.localEventsAndAnnouncementsToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.localEventsAndAnnouncementsToolStripMenuItem.Text = "Local events and Announcements";
            this.localEventsAndAnnouncementsToolStripMenuItem.Click += new System.EventHandler(this.localEventsAndAnnouncementsToolStripMenuItem_Click);
            // 
            // serviceRequestStatusToolStripMenuItem
            // 
            this.serviceRequestStatusToolStripMenuItem.Name = "serviceRequestStatusToolStripMenuItem";
            this.serviceRequestStatusToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.serviceRequestStatusToolStripMenuItem.Text = "Service Request Status";
            this.serviceRequestStatusToolStripMenuItem.Click += new System.EventHandler(this.serviceRequestStatusToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localEventsAndAnnouncementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceRequestStatusToolStripMenuItem;
    }
}

