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
        static string mediaFilePath = string.Empty;
        public ReportIssue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
           
                MessageBox.Show($"Location: {location}\nDescription: {description}\nCategory: {category}\nMedia File: {mediaFilePath}", "Issue Reported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form fields after submission
            edtLocation.Clear();
            edtDescription.Clear();
            lstCategory.SelectedIndex = -1;
            mediaFilePath = string.Empty;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                // You can now use the filePath variable to access the selected file
                MessageBox.Show("Selected file: " + filePath);
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

        private void ReportIssue_Load(object sender, EventArgs e)
        {

        }
    }
}
