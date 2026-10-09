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
    public partial class AnnounncementCard : UserControl
    {
        public AnnounncementCard()
        {
            InitializeComponent();
        }
        public void PopulateAnnouncementCard(string announcementTitle, string announcementDate, string announcementDescription)
        {
            lblTitle.Text = announcementTitle;
            lblDate.Text = announcementDate;
            lblDescription.Text = announcementDescription;
        }
    }
}
