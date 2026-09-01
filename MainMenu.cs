using GTranslate;
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
    public partial class MainMenu : Form
    {
        class Messages
        {
            public string ticketNumber { get; set; }
            public string messageContent { get; set; }
        }

        List<Messages> messageList = new List<Messages>();
        private readonly TranslationService _translationService = new TranslationService();
        public MainMenu()
        {
            InitializeComponent();
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            string selectedLangCode = AppSettings.SelectedLanguageCode;
            await TranslateFormAsync(selectedLangCode); 
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



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void localEventsAndAnnouncementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalEvents localEventsForm = new LocalEvents();
            localEventsForm.Show();
            this.Hide();
        }

        private void serviceRequestStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceRequest serviceRequestForm = new ServiceRequest();
            serviceRequestForm.Show();
            this.Hide();
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportIssue reportIssueForm = new ReportIssue();
            reportIssueForm.Show();
            this.Hide();
        }

        private async void btnMessage_Click(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;

            string prompt = await _translationService.TranslateAsync("Enter your message:", langCode);
            string title = await _translationService.TranslateAsync("Message Input", langCode);

            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                var ticket = new Messages { ticketNumber = Guid.NewGuid().ToString(), messageContent = input };
                messageList.Add(ticket);

                string confirmation = await _translationService.TranslateAsync(
                    $"Your message has been sent.\nTicket Number: {ticket.ticketNumber}\nMessage: {ticket.messageContent}",
                    langCode);

                string confirmationTitle = await _translationService.TranslateAsync("Message Sent", langCode);

                MessageBox.Show(confirmation, confirmationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string warning = await _translationService.TranslateAsync("No message was entered.", langCode);
                string warningTitle = await _translationService.TranslateAsync("No Message", langCode);

                MessageBox.Show(warning, warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void reportIssueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ReportIssue reportIssue = new ReportIssue();

            reportIssue.Show();
            this.Hide();
        }

        private async Task localEventsAndAnnouncementsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;
            string message = await _translationService.TranslateAsync("Not available at the moment, but coming soon!", langCode);
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void serviceRequestStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;
            string message = await _translationService.TranslateAsync("Not available at the moment, but coming soon!", langCode);

            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void cmbLanguage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
               if (cmbLanguage.SelectedItem == null) return;

            var selectedLang = cmbLanguage.SelectedItem.ToString();
            Console.WriteLine($"Selected language: {selectedLang}");
            string langCode = "en";

            switch (selectedLang)
            {
                case "English":
                    langCode = "en";
                    break;
                case "Zulu":
                    langCode = "zu";
                    break;
                case "Sepedi":
                    langCode = "nso";
                    break;
                case "Venda":
                    langCode = "ve";
                    break;
                case "Afrikaans":
                    langCode = "af";
                    break;
            }
            AppSettings.SelectedLanguageCode = langCode;
            await TranslateFormAsync(langCode);
        }
    }
}
