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
            this.btnMessage = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localEventsAndAnnouncementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceRequestStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMessage
            // 
            this.btnMessage.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMessage.Location = new System.Drawing.Point(544, 332);
            this.btnMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(221, 42);
            this.btnMessage.TabIndex = 2;
            this.btnMessage.Text = "Suggestion/ Feedback";
            this.btnMessage.UseVisualStyleBackColor = false;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectMenuToolStripMenuItem
            // 
            this.selectMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportIssueToolStripMenuItem,
            this.localEventsAndAnnouncementsToolStripMenuItem,
            this.serviceRequestStatusToolStripMenuItem});
            this.selectMenuToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectMenuToolStripMenuItem.Name = "selectMenuToolStripMenuItem";
            this.selectMenuToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.selectMenuToolStripMenuItem.Text = "Select Menu";
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.reportIssueToolStripMenuItem.Text = "Report Issues";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click_1);
            // 
            // localEventsAndAnnouncementsToolStripMenuItem
            // 
            this.localEventsAndAnnouncementsToolStripMenuItem.Name = "localEventsAndAnnouncementsToolStripMenuItem";
            this.localEventsAndAnnouncementsToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.localEventsAndAnnouncementsToolStripMenuItem.Text = "Local events and Announcements";
          
            // 
            // serviceRequestStatusToolStripMenuItem
            // 
            this.serviceRequestStatusToolStripMenuItem.Name = "serviceRequestStatusToolStripMenuItem";
            this.serviceRequestStatusToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.serviceRequestStatusToolStripMenuItem.Text = "Service Request status";
            this.serviceRequestStatusToolStripMenuItem.Click += new System.EventHandler(this.serviceRequestStatusToolStripMenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 170);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to Tshawne Municipality ";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "English",
            "Sepedi",
            "Zulu",
            "Venda",
            "Afrikaans "});
            this.cmbLanguage.Location = new System.Drawing.Point(569, 53);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(184, 24);
            this.cmbLanguage.TabIndex = 5;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged_1);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(781, 389);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localEventsAndAnnouncementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceRequestStatusToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}

