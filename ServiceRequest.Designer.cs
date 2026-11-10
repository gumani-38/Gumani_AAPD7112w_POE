namespace Gumani_AAPD7112w_POE
{
    partial class ServiceRequest
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnTrack = new System.Windows.Forms.Button();
            this.lstPipelineProgress = new System.Windows.Forms.ListBox();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.dgvStatusMaster = new System.Windows.Forms.DataGridView();
            this.lblDisplayTitle = new System.Windows.Forms.Label();
            this.lblDisplayCurrentStatus = new System.Windows.Forms.Label();
            this.lblDisplayLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(845, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(171, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back to Main";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTrack.Location = new System.Drawing.Point(841, 505);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(175, 39);
            this.btnTrack.TabIndex = 1;
            this.btnTrack.Text = "Track";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // lstPipelineProgress
            // 
            this.lstPipelineProgress.FormattingEnabled = true;
            this.lstPipelineProgress.ItemHeight = 16;
            this.lstPipelineProgress.Location = new System.Drawing.Point(611, 176);
            this.lstPipelineProgress.Name = "lstPipelineProgress";
            this.lstPipelineProgress.Size = new System.Drawing.Size(405, 308);
            this.lstPipelineProgress.TabIndex = 2;
            // 
            // txtSearchId
            // 
            this.txtSearchId.Location = new System.Drawing.Point(12, 129);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.Size = new System.Drawing.Size(355, 22);
            this.txtSearchId.TabIndex = 3;
            // 
            // dgvStatusMaster
            // 
            this.dgvStatusMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusMaster.Location = new System.Drawing.Point(12, 176);
            this.dgvStatusMaster.Name = "dgvStatusMaster";
            this.dgvStatusMaster.RowHeadersWidth = 51;
            this.dgvStatusMaster.RowTemplate.Height = 24;
            this.dgvStatusMaster.Size = new System.Drawing.Size(593, 312);
            this.dgvStatusMaster.TabIndex = 4;
            // 
            // lblDisplayTitle
            // 
            this.lblDisplayTitle.AutoSize = true;
            this.lblDisplayTitle.Location = new System.Drawing.Point(608, 116);
            this.lblDisplayTitle.Name = "lblDisplayTitle";
            this.lblDisplayTitle.Size = new System.Drawing.Size(44, 16);
            this.lblDisplayTitle.TabIndex = 5;
            this.lblDisplayTitle.Text = "label1";
            this.lblDisplayTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDisplayCurrentStatus
            // 
            this.lblDisplayCurrentStatus.AutoSize = true;
            this.lblDisplayCurrentStatus.Location = new System.Drawing.Point(878, 116);
            this.lblDisplayCurrentStatus.Name = "lblDisplayCurrentStatus";
            this.lblDisplayCurrentStatus.Size = new System.Drawing.Size(44, 16);
            this.lblDisplayCurrentStatus.TabIndex = 6;
            this.lblDisplayCurrentStatus.Text = "label2";
            // 
            // lblDisplayLocation
            // 
            this.lblDisplayLocation.AutoSize = true;
            this.lblDisplayLocation.Location = new System.Drawing.Point(608, 144);
            this.lblDisplayLocation.Name = "lblDisplayLocation";
            this.lblDisplayLocation.Size = new System.Drawing.Size(44, 16);
            this.lblDisplayLocation.TabIndex = 7;
            this.lblDisplayLocation.Text = "label3";
            // 
            // ServiceRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1028, 567);
            this.Controls.Add(this.lblDisplayLocation);
            this.Controls.Add(this.lblDisplayCurrentStatus);
            this.Controls.Add(this.lblDisplayTitle);
            this.Controls.Add(this.dgvStatusMaster);
            this.Controls.Add(this.txtSearchId);
            this.Controls.Add(this.lstPipelineProgress);
            this.Controls.Add(this.btnTrack);
            this.Controls.Add(this.btnBack);
            this.Name = "ServiceRequest";
            this.Text = "ServiceRequest";
            this.Load += new System.EventHandler(this.ServiceRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.ListBox lstPipelineProgress;
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.DataGridView dgvStatusMaster;
        private System.Windows.Forms.Label lblDisplayTitle;
        private System.Windows.Forms.Label lblDisplayCurrentStatus;
        private System.Windows.Forms.Label lblDisplayLocation;
    }
}