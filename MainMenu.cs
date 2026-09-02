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
        public class MessageTicket
        {
            public string TicketNumber { get; set; } = string.Empty;
            public string MessageContent { get; set; } = string.Empty;
        }

        private readonly List<MessageTicket> _messageList = new List<MessageTicket>();
        private readonly TranslationService _translationService = new TranslationService();

   
        private readonly Dictionary<Control, string> _originalControlTexts = new Dictionary<Control, string>();
        private readonly Dictionary<ToolStripItem, string> _originalMenuItemTexts = new Dictionary<ToolStripItem, string>();
        private string _originalFormTitle = string.Empty;
        private bool _isTextsCaptured = false;

        public MainMenu()
        {
            InitializeComponent();
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
         
            if (!_isTextsCaptured)
            {
                CaptureOriginalTexts();
            }

            string selectedLangCode = AppSettings.SelectedLanguageCode ?? "en";
            await TranslateFormAsync(selectedLangCode);

            switch (selectedLangCode)
            {
                case "en":
                    cmbLanguage.SelectedItem = "English";
                    break;
                case "zu":
                    cmbLanguage.SelectedItem = "Zulu";
                    break;
                case "nso":
                    cmbLanguage.SelectedItem = "Sepedi";
                    break;
                case "ve":
                    cmbLanguage.SelectedItem = "Venda";
                    break;
                case "af":
                    cmbLanguage.SelectedItem = "Afrikaans";
                    break;
                default:
                   cmbLanguage.SelectedItem = "English"; // Fallback to English
                    break;
            }
        }

        private void CaptureOriginalTexts()
        {
            _originalFormTitle = this.Text;
            _originalControlTexts.Clear();
            _originalMenuItemTexts.Clear();

            GetAllControls(this);

   
            if (this.MainMenuStrip != null)
            {
                foreach (ToolStripItem item in this.MainMenuStrip.Items)
                {
                    CaptureMenuItems(item);
                }
            }

            _isTextsCaptured = true;
        }

        private void GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                
                if (control == cmbLanguage) continue;

                if (!string.IsNullOrWhiteSpace(control.Text))
                {
                    _originalControlTexts[control] = control.Text;
                }

                if (control.HasChildren)
                {
                    GetAllControls(control);
                }
            }
        }

        private void CaptureMenuItems(ToolStripItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.Text))
            {
                _originalMenuItemTexts[item] = item.Text;
            }

            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    CaptureMenuItems(subItem);
                }
            }
        }

        private async Task TranslateFormAsync(string targetLang)
        {
            var textsToTranslate = new List<string> { _originalFormTitle };
            textsToTranslate.AddRange(_originalControlTexts.Values);
            textsToTranslate.AddRange(_originalMenuItemTexts.Values);

            var translations = await _translationService.TranslateBatchAsync(textsToTranslate, targetLang);

 
            if (translations.TryGetValue(_originalFormTitle, out string translatedTitle))
            {
                this.Text = translatedTitle;
            }

            foreach (var kvp in _originalControlTexts)
            {
                if (translations.TryGetValue(kvp.Value, out string translatedText))
                {
                    kvp.Key.Text = translatedText;
                }
            }

            foreach (var kvp in _originalMenuItemTexts)
            {
                if (translations.TryGetValue(kvp.Value, out string translatedText))
                {
                    kvp.Key.Text = translatedText;
                }
            }
        }


        private void reportIssueToolStripMenuItem_Click_1(object sender, EventArgs e)
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
                var ticket = new MessageTicket { TicketNumber = Guid.NewGuid().ToString(), MessageContent = input };
                _messageList.Add(ticket);

                string messageTemplate = "Your message has been sent.\nTicket Number: {0}\nMessage: {1}";
                string translatedTemplate = await _translationService.TranslateAsync(messageTemplate, langCode);

                string confirmation = string.Format(translatedTemplate, ticket.TicketNumber, ticket.MessageContent);
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

        private async void localEventsAndAnnouncementsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;
            string message = await _translationService.TranslateAsync("Not available at the moment, but coming soon!", langCode);
            string title = await _translationService.TranslateAsync("Information", langCode);
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void serviceRequestStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string langCode = AppSettings.SelectedLanguageCode;
            string message = await _translationService.TranslateAsync("Not available at the moment, but coming soon!", langCode);
            string title = await _translationService.TranslateAsync("Information", langCode);

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void cmbLanguage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem == null) return;


            if (!_isTextsCaptured)
            {
                CaptureOriginalTexts();
            }

            var selectedLang = cmbLanguage.SelectedItem.ToString();
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
