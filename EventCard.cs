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
    public partial class EventCard : UserControl
    {
        public EventCard()
        {
            InitializeComponent();
        }

        public void PopulateEventCard(string eventName, string eventDate, string eventLocation, string eventDescription, string eventCategory)
        {
            lblTitle.Text = eventName;
            lblDate.Text = eventDate;
            lblDescription.Text = eventDescription;
            lblLocation.Text = eventLocation;
            lblCategory.Text = eventCategory;
        }

    }
}
