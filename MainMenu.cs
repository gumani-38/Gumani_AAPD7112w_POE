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
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {


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

        private void btnMessage_Click(object sender, EventArgs e)
        {

           string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your message:", "Message Input", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                messageList.Add(new Messages { ticketNumber = Guid.NewGuid().ToString(), messageContent = input });
                MessageBox.Show($"Your message has been sent.\nTicket Number: {messageList.Last().ticketNumber}\nMessage: {messageList.Last().messageContent}", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No message was entered.", "No Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reportIssueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ReportIssue reportIssue = new ReportIssue();

            reportIssue.Show();
            this.Hide();
        }

        private void localEventsAndAnnouncementsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Not available at the moment, but coming soon!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void serviceRequestStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Not available at the moment, but coming soon!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
