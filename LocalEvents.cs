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
    public partial class LocalEvents : Form
    {
    
        private SortedDictionary<string, Event> eventDictionary = new SortedDictionary<string, Event>();
        private Queue<Announcement> announcementQueue = new Queue<Announcement>();
        private Stack<string> searchHistoryStack = new Stack<string>();
        private HashSet<string> uniqueCategories = new HashSet<string>();
        private Dictionary<string, int> categoryPreferences = new Dictionary<string, int>();
  

        public LocalEvents()
        {
            InitializeComponent();

            
              txtSearchValue.TextChanged += TxtSearch_TextChanged;
            datePickerEvent.ValueChanged += DatePickerEvent_ValueChanged;
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
        }

        public class Announcement
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }

        public class Event
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
        }

        private void LocalEvents_Load(object sender, EventArgs e)
        {

            DataPopulate();
            DisplayAnnouncements();
            DisplayEvents(eventDictionary.Values); 
            PopulateCategoriesUI();
        }

        private void DataPopulate()
        {
           
            announcementQueue.Enqueue(new Announcement { Title = "Community sanitation", Description = "Join us for a community clean-up event at the local park.", Date = new DateTime(2026, 5, 15) });
            announcementQueue.Enqueue(new Announcement { Title = "Charity Fundraiser", Description = "Support our local charity by attending our fundraising event.", Date = new DateTime(2026, 6, 20) });
            announcementQueue.Enqueue(new Announcement { Title = "Summer Sports Camp", Description = "Enroll your kids in our summer sports camp for fun and fitness.", Date = new DateTime(2026, 6, 22) });
            announcementQueue.Enqueue(new Announcement { Title = "Farmers Market", Description = "Visit our farmers market for fresh produce and local goods.", Date = new DateTime(2026, 7, 28) });
            announcementQueue.Enqueue(new Announcement { Title = "Neighborhood Watch Meeting", Description = "Attend our neighborhood watch meeting to discuss safety concerns.", Date = new DateTime(2026, 6, 29) });


            AddEvent(new Event { Name = "Music Festival", Location = "City Square", Description = "Enjoy live music performances from local bands.", Date = new DateTime(2026, 9, 10), Category = "Entertainment" });
            AddEvent(new Event { Name = "Art Exhibition", Location = "Community Center", Description = "Explore the works of local artists at our art exhibition.", Date = new DateTime(2026, 6, 30), Category = "Culture" });
            AddEvent(new Event { Name = "Food Truck Rally", Location = "Downtown", Description = "Sample delicious food from a variety of food trucks.", Date = new DateTime(2026, 7, 5), Category = "Food" });
            AddEvent(new Event { Name = "Outdoor Movie Night", Location = "City Park", Description = "Bring your blankets and enjoy a movie under the stars.", Date = new DateTime(2026, 5, 10), Category = "Entertainment" });
            AddEvent(new Event { Name = "Charity Run", Location = "Riverfront Trail", Description = "Participate in our charity run to support a good cause.", Date = new DateTime(2026, 7, 15), Category = "Charity" });
        }

        private void AddEvent(Event ev)
        {
            if (!eventDictionary.ContainsKey(ev.Name))
            {
                eventDictionary.Add(ev.Name, ev);
                uniqueCategories.Add(ev.Category); 
            }
        }

        private void DisplayEvents(IEnumerable<Event> eventsToDisplay)
        {
            flowEvents.Controls.Clear();
            foreach (var ev in eventsToDisplay)
            {
                EventCard card = new EventCard();
                card.PopulateEventCard(ev.Name, ev.Date.ToShortDateString(), ev.Location, ev.Description, ev.Category);
                flowEvents.Controls.Add(card);
            }
        }

        private void DisplayAnnouncements()
        {
            flowAnnouncements.Controls.Clear();
            foreach (var an in announcementQueue)
            {
                AnnounncementCard card = new AnnounncementCard();
                card.PopulateAnnouncementCard(an.Title, an.Date.ToShortDateString(), an.Description);
                flowAnnouncements.Controls.Add(card);
            }
        }

        private void PopulateCategoriesUI()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Any Categories");
            foreach (var category in uniqueCategories)
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0;
        }


        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndTrackPatterns();
        }

        private void DatePickerEvent_ValueChanged(object sender, EventArgs e)
        {
            if (chkDateEnabler.Checked)
            {
                ExecuteSearchAndTrackPatterns();
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cmbCategory.Focused)
            {
                ExecuteSearchAndTrackPatterns();
            }
        }
 
        private void ExecuteSearchAndTrackPatterns()
        {
            
            string keyword = txtSearchValue.Text.Trim();
            DateTime selectedDate = datePickerEvent.Value.Date; 
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            bool useDateFilter = chkDateEnabler.Checked;

            // Prevents duplicate consecutive entries 
            if (!string.IsNullOrEmpty(keyword) && (searchHistoryStack.Count == 0 || searchHistoryStack.Peek() != keyword))
            {
                searchHistoryStack.Push(keyword);
            }

           
            bool hasKeyword = !string.IsNullOrEmpty(keyword);
            bool hasCategory = !string.IsNullOrEmpty(selectedCategory) && !selectedCategory.Equals("Any Categories", StringComparison.OrdinalIgnoreCase);

            // Sorted Dictionary values
            var filteredResults = eventDictionary.Values.Where(ev =>
               
                (!hasKeyword || ev.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || ev.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) &&

              
                (!hasCategory || ev.Category.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase)) &&

               (!useDateFilter || (ev.Date.Year == selectedDate.Year &&
                            ev.Date.Month == selectedDate.Month &&
                            ev.Date.Day == selectedDate.Day))
            ).ToList();


            DisplayEvents(filteredResults);

       
            foreach (var ev in filteredResults)
            {
                if (ev.Category != null)
                {
                    categoryPreferences[ev.Category] = categoryPreferences.TryGetValue(ev.Category, out int count) ? count + 1 : 1;
                }
            }

     
            UserRecommendations();
        }

        private void UserRecommendations()
        {
            if (categoryPreferences.Count == 0) return;

            string recommendedCategory = categoryPreferences.OrderByDescending(x => x.Value).First().Key;
            if (cmbCategory.SelectedItem?.ToString() == "Any Categories")
            {
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    if (cmbCategory.Items[i].ToString().Equals(recommendedCategory, StringComparison.OrdinalIgnoreCase))
                    {
                      
                        break;
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndTrackPatterns(); 

        }
    }
}
