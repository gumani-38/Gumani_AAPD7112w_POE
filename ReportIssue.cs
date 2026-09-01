using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gumani_AAPD7112w_POE
{

    public partial class ReportIssue : Form
    {
        class IssueReport
        {
            public string Location { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string MediaFilePath { get; set; }

            public string status { get; set; } = "Pending"; // Default status is "Pending"
            public IssueReport(string location, string description, string category, string mediaFilePath)
            {
                Location = location;
                Description = description;
                Category = category;
                MediaFilePath = mediaFilePath;
            }
        }
        static string mediaFilePath = string.Empty;
        static List<IssueReport> issueReportsQueue = new List<IssueReport>();
        private readonly TranslationService _translationService = new TranslationService();
        public ReportIssue()
        {
            InitializeComponent();
        }
      

        private async void button1_Click(object sender, EventArgs e)
        {
            string location = edtLocation.Text;
            string description = edtDescription.Text;
            string category = lstCategory.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(location))
            {
                
                MessageBox.Show("Please enter a location.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a category.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(mediaFilePath))
            {
                MessageBox.Show("Please attach a media file.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnSubmit.Enabled = false;
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 30;
                lblStatus.Text = "Submittion in Progress...";

                await Task.Delay(2000);

                lblStatus.Text = await _translationService.TranslateAsync("Submittion Complete!", AppSettings.SelectedLanguageCode);

                MessageBox.Show($"Location: {location}\nDescription: {description}\nCategory: {category}\nMedia File: {mediaFilePath}", await _translationService.TranslateAsync("Issue Reported", AppSettings.SelectedLanguageCode)    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                IssueReport newIssueReport = new IssueReport(location, description, category, mediaFilePath);
                issueReportsQueue.Add(newIssueReport);
                PrintQueueContents();

                // Clear the form fields after submission          
               edtLocation.Clear();
                edtDescription.Clear();
                lstCategory.SelectedIndex = -1;
                mediaFilePath = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = await _translationService.TranslateAsync("Submittion Failed!", AppSettings.SelectedLanguageCode);
                MessageBox.Show($"An error occurred during submission: {ex.Message}", await _translationService.TranslateAsync("Error", AppSettings.SelectedLanguageCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset everything back to normal
                progressBar.Visible = false;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = 0;
                btnSubmit.Enabled = true;
                lblStatus.Text = null;
            }
        


        }
        private void PrintQueueContents()
        {
            System.Diagnostics.Debug.WriteLine("================ CURRENT LIST ================");
            System.Diagnostics.Debug.WriteLine($"Total items in list: {issueReportsQueue.Count}");

            int count = 1;
            foreach (IssueReport issue in issueReportsQueue)
            {
                System.Diagnostics.Debug.WriteLine($"[{count}] Category: {issue.Category} | Location: {issue.Location} | Description: {issue.Description} | Media File: {issue.MediaFilePath}") ;
                count++;
            }
            System.Diagnostics.Debug.WriteLine("====================================================");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private async void btnAttachMedia_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                // You can now use the filePath variable to access the selected file
                string langCode = AppSettings.SelectedLanguageCode;
                string translatedMessage = await _translationService.TranslateAsync("Selected file: ", langCode);
                MessageBox.Show(translatedMessage + filePath);
                mediaFilePath = filePath;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenu mainMenuForm = new MainMenu();

            mainMenuForm.ShowDialog();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ReportIssue_Load(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;
            await TranslateFormAsync(langCode);
        }
        private async Task TranslateFormAsync(string targetLang)
        {
            foreach (Control control in this.Controls)
            {
                if (!string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Text = await _translationService.TranslateAsync(control.Text, targetLang);
                }
            }

            this.Text = await _translationService.TranslateAsync(this.Text, targetLang);
        }

    }
}
