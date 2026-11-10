using System;
using System.Collections.Generic;

namespace Gumani_AAPD7112w_POE
{
   
    public class IssueReport
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string MediaFilePath { get; set; }
        public string status { get; set; } = "Pending";

  
        public string UniqueId { get; set; }       
        public int PriorityScore { get; set; }     // Used for Heap / Priority Queue structuring (1 = High, 3 = Low)
        public DateTime DateLogged { get; set; } = DateTime.Now;
    }

    public static class DataStore
    {
        // Active local storage container for all submitted reports
        public static List<IssueReport> LocalRequests = new List<IssueReport>();

        // Counter used to generate consecutive unique tracking identification codes
        private static int nextIdCount = 1003;

        static DataStore()
        {
            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1001",
                Location = "Pretoria CBD, Church Street",
                Description = "Deep pothole damaging car tires near intersection.",
                Category = "Roads & Stormwater",
                MediaFilePath = "",
                PriorityScore = 1,
                status = "Report Logged",
                DateLogged = DateTime.Now.AddDays(-2)
            });

            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1002",
                Location = "Hatfield, Burnett St",
                Description = "Burst water pipe flooding the sidewalk.",
                Category = "Water & Sanitation",
                MediaFilePath = "",
                PriorityScore = 2,
                status = "Verification Pending",
                DateLogged = DateTime.Now.AddDays(-1)
            });

            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1003",
                Location = "Arcadia, Stanza Bopape St",
                Description = "Streetlight not working, area is dark at night.",
                Category = "Electricity & Streetlights",
                MediaFilePath = "",
                PriorityScore = 3,
                status = "Report Logged",
                DateLogged = DateTime.Now.AddDays(-3)
            });
            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1004",
                Location = "Muckleneuk, Hamilton St",
                Description = "Overflowing garbage bin attracting pests.",
                Category = "Waste Management",
                MediaFilePath = "",
                PriorityScore = 2,
                status = "Verification Pending",
                DateLogged = DateTime.Now.AddDays(-1)
            });
            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1005",
                Location = "Brooklyn, Fehrsen St",
                Description = "Graffiti on public wall, needs cleaning.",
                Category = "Public Safety & Security",
                MediaFilePath = "",
                PriorityScore = 3,
                status = "Report Logged",
                DateLogged = DateTime.Now.AddDays(-4)
            });

            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1006",
                Location = "Muckleneuk, Hamilton St",
                Description = "Overflowing garbage bin attracting pests.",
                Category = "Waste Management",
                MediaFilePath = "",
                PriorityScore = 2,
                status = "Verification Pending",
                DateLogged = DateTime.Now.AddDays(-1)
            });

            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1007",
                Location = "Brooklyn, Fehrsen St",
                Description = "Graffiti on public wall, needs cleaning.",
                Category = "Public Safety & Security",
                MediaFilePath = "",
                PriorityScore = 3,
                status = "Report Logged",
                DateLogged = DateTime.Now.AddDays(-4)
            });

            LocalRequests.Add(new IssueReport
            {
                UniqueId = "REQ-1008",
                Location = "Pretoria CBD, Church Street",
                Description = "Deep pothole damaging car tires near intersection.",
                Category = "Roads & Stormwater",
                MediaFilePath = "",
                PriorityScore = 1,
                status = "Report Logged",
                DateLogged = DateTime.Now.AddDays(-2)
            });


        }


        public static string AddNewRequest(string location, string description, string category, string mediaPath, int priority)
        {
            // Auto-increment the tracking code structure
            string generatedId = $"REQ-{nextIdCount++}";

            IssueReport newReport = new IssueReport
            {
                UniqueId = generatedId,
                Location = location,
                Description = description,
                Category = category,
                MediaFilePath = mediaPath,
                PriorityScore = priority,
                status = "Report Logged",
                DateLogged = DateTime.Now
            };

            LocalRequests.Add(newReport);
            return generatedId;
        }
    }
}
