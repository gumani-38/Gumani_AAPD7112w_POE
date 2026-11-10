
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
     
        private SortedDictionary<string, Event> eventDictionary =
            new SortedDictionary<string, Event>();

        private Queue<Announcement> announcementQueue =
            new Queue<Announcement>();

        private Stack<string> searchHistoryStack =
            new Stack<string>();

        private HashSet<string> uniqueCategories =
            new HashSet<string>();

        // Recommendation data structures
        private Dictionary<string, int> categoryPreferences =
            new Dictionary<string, int>();

        private Dictionary<string, int> searchTermPreferences =
            new Dictionary<string, int>();

        // Prevents the same search from being counted repeatedly
        private HashSet<string> processedSearches =
            new HashSet<string>();

        // Delays search processing while the user types
        private System.Windows.Forms.Timer searchDebounceTimer;


        public LocalEvents()
        {
            InitializeComponent();

            txtSearchValue.TextChanged += TxtSearch_TextChanged;

            datePickerEvent.ValueChanged += DatePickerEvent_ValueChanged;

            cmbCategory.SelectedIndexChanged +=
                CmbCategory_SelectedIndexChanged;

            searchDebounceTimer =
                new System.Windows.Forms.Timer();

            searchDebounceTimer.Interval = 600;

            searchDebounceTimer.Tick += (s, e) =>
            {
                searchDebounceTimer.Stop();
                ExecuteSearchAndTrackPatterns();
            };

            this.FormClosed += (s, e) =>
            {
                searchDebounceTimer.Dispose();
            };
        }


        // Announcement model
        public class Announcement
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }


        // Event model
        public class Event
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
        }


        // Form loading
        private void LocalEvents_Load(object sender, EventArgs e)
        {
            DataPopulate();

            DisplayAnnouncements();

            DisplayEvents(eventDictionary.Values);

            PopulateCategoriesUI();

            // Display initial recommendation message
            UserRecommendations(new List<Event>());
        }


        // Populate sample data
        private void DataPopulate()
        {
            announcementQueue.Enqueue(new Announcement
            {
                Title = "Community sanitation",
                Description = "Join us for a community clean-up event at the local park.",
                Date = new DateTime(2026, 5, 15)
            });

            announcementQueue.Enqueue(new Announcement
            {
                Title = "Charity Fundraiser",
                Description = "Support our local charity by attending our fundraising event.",
                Date = new DateTime(2026, 6, 20)
            });

            announcementQueue.Enqueue(new Announcement
            {
                Title = "Summer Sports Camp",
                Description = "Enroll your kids in our summer sports camp for fun and fitness.",
                Date = new DateTime(2026, 6, 22)
            });

            announcementQueue.Enqueue(new Announcement
            {
                Title = "Farmers Market",
                Description = "Visit our farmers market for fresh produce and local goods.",
                Date = new DateTime(2026, 7, 28)
            });

            announcementQueue.Enqueue(new Announcement
            {
                Title = "Neighborhood Watch Meeting",
                Description = "Attend our neighborhood watch meeting to discuss safety concerns.",
                Date = new DateTime(2026, 6, 29)
            });


            // Events
            AddEvent(new Event
            {
                Name = "Music Festival",
                Location = "City Square",
                Description = "Enjoy live music performances from local bands.",
                Date = new DateTime(2026, 9, 10),
                Category = "Entertainment"
            });

            AddEvent(new Event
            {
                Name = "Art Exhibition",
                Location = "Community Center",
                Description = "Explore the works of local artists at our art exhibition.",
                Date = new DateTime(2026, 6, 30),
                Category = "Culture"
            });

            AddEvent(new Event
            {
                Name = "Food Truck Rally",
                Location = "Downtown",
                Description = "Sample delicious food from a variety of food trucks.",
                Date = new DateTime(2026, 7, 5),
                Category = "Food"
            });

            AddEvent(new Event
            {
                Name = "Outdoor Movie Night",
                Location = "City Park",
                Description = "Bring your blankets and enjoy a movie under the stars.",
                Date = new DateTime(2026, 5, 10),
                Category = "Entertainment"
            });

            AddEvent(new Event
            {
                Name = "Charity Run",
                Location = "Riverfront Trail",
                Description = "Participate in our charity run to support a good cause.",
                Date = new DateTime(2026, 7, 15),
                Category = "Charity"
            });

          AddEvent(new Event
          {
              Name = "Farmers Market",
              Location = "Town Square",
              Description = "Shop for fresh produce and local goods at our farmers market.",
              Date = new DateTime(2026, 8, 20),
              Category = "Food"
          });
            AddEvent(new Event
            {
                Name = "Community Workshop",
                Location = "Library",
                Description = "Join us for a community workshop on sustainable living.",
                Date = new DateTime(2026, 9, 5),
                Category = "Charity"
            });
            AddEvent(new Event
            {
                Name = "Local Theater Performance",
                Location = "Theater Hall",
                Description = "Experience a captivating performance by our local theater group.",
                Date = new DateTime(2026, 10, 12),
                Category = "Culture"
            });
            AddEvent(new Event
            {
                Name = "Charity Gala",
                Location = "Grand Ballroom",
                Description = "Attend our charity gala to support a worthy cause.",
                Date = new DateTime(2026, 11, 18),
                Category = "Charity"
            });
            AddEvent(new Event
            {
                Name = "Outdoor Yoga Session",
                Location = "City Park",
                Description = "Join us for a relaxing outdoor yoga session in the park.",
                Date = new DateTime(2026, 7, 25),
                Category = "Entertainment"
            });
        }


        // Add event to SortedDictionary
        private void AddEvent(Event ev)
        {
            if (!eventDictionary.ContainsKey(ev.Name))
            {
                eventDictionary.Add(ev.Name, ev);

                uniqueCategories.Add(ev.Category);
            }
        }


        // Display normal events
        private void DisplayEvents(IEnumerable<Event> eventsToDisplay)
        {
            flowEvents.Controls.Clear();

            foreach (var ev in eventsToDisplay)
            {
                EventCard card = new EventCard();

                card.PopulateEventCard(
                    ev.Name,
                    ev.Date.ToShortDateString(),
                    ev.Location,
                    ev.Description,
                    ev.Category
                );

                flowEvents.Controls.Add(card);
            }
        }


        // Display announcements
        private void DisplayAnnouncements()
        {
            flowAnnouncements.Controls.Clear();

            foreach (var an in announcementQueue)
            {
                AnnounncementCard card =
                    new AnnounncementCard();

                card.PopulateAnnouncementCard(
                    an.Title,
                    an.Date.ToShortDateString(),
                    an.Description
                );

                flowAnnouncements.Controls.Add(card);
            }
        }


        // Populate category dropdown
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


        // Search textbox event
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            searchDebounceTimer.Stop();

            searchDebounceTimer.Start();
        }


        // Date picker event
        private void DatePickerEvent_ValueChanged(object sender, EventArgs e)
        {
            if (chkDateEnabler.Checked)
            {
                ExecuteSearchAndTrackPatterns();
            }
        }


        // Category selection event
        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.Focused)
            {
                ExecuteSearchAndTrackPatterns();
            }
        }


        // Execute search and analyse user behaviour
        private void ExecuteSearchAndTrackPatterns()
        {
            string keyword = txtSearchValue.Text.Trim();

            DateTime selectedDate = datePickerEvent.Value.Date;

            string selectedCategory =
                cmbCategory.SelectedItem?.ToString();

            bool useDateFilter = chkDateEnabler.Checked;

            bool hasKeyword =
                !string.IsNullOrWhiteSpace(keyword);

            bool hasCategory =
                !string.IsNullOrWhiteSpace(selectedCategory) &&
                !selectedCategory.Equals(
                    "Any Categories",
                    StringComparison.OrdinalIgnoreCase
                );


            // Filter events based on user input
            var filteredResults = eventDictionary.Values.Where(ev =>

                (
                    !hasKeyword ||

                    ev.Name.IndexOf(
                        keyword,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0 ||

                    ev.Description.IndexOf(
                        keyword,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0 ||

                    ev.Location.IndexOf(
                        keyword,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0 ||

                    ev.Category.IndexOf(
                        keyword,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0
                )

                &&

                (
                    !hasCategory ||

                    ev.Category.Equals(
                        selectedCategory,
                        StringComparison.OrdinalIgnoreCase
                    )
                )

                &&

                (
                    !useDateFilter ||
                    ev.Date.Date == selectedDate
                )

            ).ToList();


            // Display filtered search results
            DisplayEvents(filteredResults);


            // Track actual user searches
            if (hasKeyword || hasCategory)
            {
                TrackSearchPatterns(
                    keyword,
                    selectedCategory,
                    filteredResults,
                    hasCategory,
                    selectedDate,
                    useDateFilter
                );
            }


            // Generate recommendations
            UserRecommendations(filteredResults);
        }


        // Analyse search patterns and user preferences
        private void TrackSearchPatterns(
            string keyword,
            string selectedCategory,
            List<Event> results,
            bool hasCategory,
            DateTime selectedDate,
            bool useDateFilter)
        {
           
            if (results.Count == 0)
                return;


            // Create a unique search identifier
            string searchKey =
                keyword.ToLowerInvariant() + "|" +
                (selectedCategory ?? "").ToLowerInvariant() + "|" +
                (useDateFilter ? selectedDate.ToString("yyyy-MM-dd") : "all");


            // Prevent duplicate search tracking
            if (!processedSearches.Add(searchKey))
                return;


            // Store search history
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                if (searchHistoryStack.Count == 0 ||
                    !searchHistoryStack.Peek().Equals(
                        keyword,
                        StringComparison.OrdinalIgnoreCase))
                {
                    searchHistoryStack.Push(keyword);
                }


                // Extract individual search terms
                string[] words = keyword
                    .ToLowerInvariant()
                    .Split(
                        new char[] { ' ', ',', '.', '-', '_' },
                        StringSplitOptions.RemoveEmptyEntries
                    );


                foreach (string word in words)
                {
                    if (word.Length < 2)
                        continue;

                    searchTermPreferences[word] =
                        searchTermPreferences.TryGetValue(
                            word,
                            out int count
                        )
                        ? count + 1
                        : 1;
                }
            }


            // Explicit category selection gets a higher score
            if (hasCategory)
            {
                categoryPreferences[selectedCategory] =
                    categoryPreferences.TryGetValue(
                        selectedCategory,
                        out int count
                    )
                    ? count + 3
                    : 3;
            }


            // Learn from categories in matching search results
            foreach (Event ev in results)
            {
                if (!string.IsNullOrWhiteSpace(ev.Category))
                {
                    categoryPreferences[ev.Category] =
                        categoryPreferences.TryGetValue(
                            ev.Category,
                            out int count
                        )
                        ? count + 1
                        : 1;
                }
            }
        }


        // Recommendation algorithm
        private void UserRecommendations(List<Event> currentResults)
        {
            flowRecommendations.Controls.Clear();


            // Calculate recommendation scores
            var recommendedEvents = eventDictionary.Values

                // Do not recommend events already in search results
                .Where(ev => !currentResults.Contains(ev))

                .Select(ev =>
                {
                    int score = 0;


                    // Category preference scoring
                    if (categoryPreferences.TryGetValue(
                        ev.Category,
                        out int categoryScore))
                    {
                        score += categoryScore * 3;
                    }


                    // Search keyword similarity scoring
                    string eventInformation =

                        (ev.Name + " " +
                         ev.Description + " " +
                         ev.Location + " " +
                         ev.Category).ToLowerInvariant();


                    foreach (var term in searchTermPreferences)
                    {
                        if (eventInformation.Contains(term.Key))
                        {
                            score += term.Value * 2;
                        }
                    }


                    return new
                    {
                        Event = ev,
                        Score = score
                    };

                })

                // Only recommend events with positive scores
                .Where(x => x.Score > 0)

               
                .OrderByDescending(x => x.Score)

            
                .ThenBy(x => x.Event.Date)

                .Take(3)

                .ToList();


            // No recommendations available
            if (recommendedEvents.Count == 0)
            {
                Label message = new Label();

                message.Text =
                    "No recommendations yet. Search for events to receive personalised suggestions.";

                message.AutoSize = true;

                message.Padding = new Padding(10);

                message.ForeColor = Color.Gray;

                flowRecommendations.Controls.Add(message);

                return;
            }


            // Display recommended events and their scores
            foreach (var recommendation in recommendedEvents)
            {
                Event ev = recommendation.Event;

                EventCard card = new EventCard();

                card.PopulateEventCard(
                    ev.Name,
                    ev.Date.ToShortDateString(),
                    ev.Location,
                    ev.Description,
                    ev.Category
                );

                flowRecommendations.Controls.Add(card);


                // Display recommendation score for testing
                Label scoreLabel = new Label();

                scoreLabel.Text =
                    "Recommendation Score: " +
                    recommendation.Score;

                scoreLabel.AutoSize = true;

                scoreLabel.ForeColor = Color.Green;

                scoreLabel.Font =
                    new Font("Arial", 9, FontStyle.Bold);

                scoreLabel.Padding = new Padding(5);

                flowRecommendations.Controls.Add(scoreLabel);
            }
        }


        // Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenu mainMenuForm = new MainMenu();

            mainMenuForm.Show();
        }


        // Date filter checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndTrackPatterns();
        }
    }
}
