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
    }
}
