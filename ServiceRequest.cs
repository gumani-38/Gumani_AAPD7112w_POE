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
    public partial class ServiceRequest : Form
    {
        private ServiceRequestBST structuralSearchTree;
        private ServiceWorkflowGraph municipalWorkflow;
        public ServiceRequest()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.Show();

        }

        private void ServiceRequest_Load(object sender, EventArgs e)
        {
            // Reset and build structures dynamically from the active DataStore state
            structuralSearchTree = new ServiceRequestBST();
            municipalWorkflow = new ServiceWorkflowGraph();

            // Populate the structural algorithm indexes
            foreach (IssueReport issue in DataStore.LocalRequests)
            {
                structuralSearchTree.Insert(issue);
            }

            // Bind values directly into our master UI data grid view list
            RefreshDisplayGrid();

        }
        private void RefreshDisplayGrid()
        {
            dgvStatusMaster.Rows.Clear();
            dgvStatusMaster.Columns.Clear();

          
            dgvStatusMaster.Columns.Add("UniqueId", "Tracking ID");
            dgvStatusMaster.Columns.Add("Priority", "Priority"); 
            dgvStatusMaster.Columns.Add("Category", "Category");
            dgvStatusMaster.Columns.Add("Location", "Location");
            dgvStatusMaster.Columns.Add("Status", "Current Status");
            dgvStatusMaster.Columns.Add("DateLogged", "Date Logged");

            dgvStatusMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

       
            IssueMinHeap prioritySorter = new IssueMinHeap();

        
            foreach (var issue in DataStore.LocalRequests)
            {
                prioritySorter.Insert(issue);
            }


            while (prioritySorter.Count > 0)
            {
                IssueReport urgentIssue = prioritySorter.ExtractMin();

                dgvStatusMaster.Rows.Add(
                    urgentIssue.UniqueId,
                    $"Level {urgentIssue.PriorityScore}", 
                    urgentIssue.Category,
                    urgentIssue.Location,
                    urgentIssue.status,
                    urgentIssue.DateLogged.ToString("yyyy-MM-dd HH:mm")
                );
            }
        }


        private void btnTrack_Click(object sender, EventArgs e)
        {
            string searchKey = txtSearchId.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchKey))
            {
                MessageBox.Show("Please key in a valid Unique ID to look up.", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // O(log n) BST lookup performance
            IssueReport trackedIssue = structuralSearchTree.Search(searchKey);

            if (trackedIssue != null)
            {
                // Update detail display UI components
                lblDisplayTitle.Text = $"Category: {trackedIssue.Category}";
                lblDisplayCurrentStatus.Text = $"Status: {trackedIssue.status}";
                lblDisplayLocation.Text = $"Location: {trackedIssue.Location}";

                // Structural graph pipeline traversal for progress tracking
                List<string> trackingSteps = municipalWorkflow.TrackMilestonePipeline(trackedIssue.status);

                lstPipelineProgress.Items.Clear();
                foreach (string step in trackingSteps)
                {
                    // Prepend indicator to flag the current step position visually
                    if (step == trackedIssue.status)
                        lstPipelineProgress.Items.Add($" CURRENT -> {step}");
                    else
                        lstPipelineProgress.Items.Add($"   NEXT ---> {step}");
                }
            }
            else
            {
                MessageBox.Show($"Tracking record \"{searchKey}\" could not be verified in the local ledger.", "Lookup Fault", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
