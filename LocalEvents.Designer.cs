namespace Gumani_AAPD7112w_POE
{
    partial class LocalEvents
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowAnnouncements = new System.Windows.Forms.FlowLayoutPanel();
            this.flowEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.datePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDateEnabler = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(1111, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 39);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back to Main";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Announcements";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(719, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Events";
            // 
            // flowAnnouncements
            // 
            this.flowAnnouncements.AutoScroll = true;
            this.flowAnnouncements.Location = new System.Drawing.Point(16, 132);
            this.flowAnnouncements.Name = "flowAnnouncements";
            this.flowAnnouncements.Size = new System.Drawing.Size(665, 470);
            this.flowAnnouncements.TabIndex = 6;
            // 
            // flowEvents
            // 
            this.flowEvents.AutoScroll = true;
            this.flowEvents.Location = new System.Drawing.Point(723, 231);
            this.flowEvents.Name = "flowEvents";
            this.flowEvents.Size = new System.Drawing.Size(509, 371);
            this.flowEvents.TabIndex = 7;
            // 
            // datePickerEvent
            // 
            this.datePickerEvent.Location = new System.Drawing.Point(723, 198);
            this.datePickerEvent.Name = "datePickerEvent";
            this.datePickerEvent.Size = new System.Drawing.Size(275, 22);
            this.datePickerEvent.TabIndex = 8;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Water",
            "Music",
            "Cleaning",
            "Elections"});
            this.cmbCategory.Location = new System.Drawing.Point(1004, 196);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(228, 24);
            this.cmbCategory.TabIndex = 9;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.Location = new System.Drawing.Point(723, 142);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(509, 24);
            this.txtSearchValue.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search by event name...";
            // 
            // chkDateEnabler
            // 
            this.chkDateEnabler.AutoSize = true;
            this.chkDateEnabler.Location = new System.Drawing.Point(723, 172);
            this.chkDateEnabler.Name = "chkDateEnabler";
            this.chkDateEnabler.Size = new System.Drawing.Size(96, 20);
            this.chkDateEnabler.TabIndex = 11;
            this.chkDateEnabler.Text = "date Active";
            this.chkDateEnabler.UseVisualStyleBackColor = true;
            this.chkDateEnabler.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LocalEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1244, 614);
            this.Controls.Add(this.chkDateEnabler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.datePickerEvent);
            this.Controls.Add(this.flowEvents);
            this.Controls.Add(this.flowAnnouncements);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.btnBack);
            this.Name = "LocalEvents";
            this.Text = "LocalEvents";
            this.Load += new System.EventHandler(this.LocalEvents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowAnnouncements;
        private System.Windows.Forms.FlowLayoutPanel flowEvents;
        private System.Windows.Forms.DateTimePicker datePickerEvent;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDateEnabler;
    }
}