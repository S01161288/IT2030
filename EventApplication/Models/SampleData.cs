using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EventApplication.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<EventApplicationDB>
    {
        protected override void Seed(EventApplicationDB context)
        {
            var eventTypes = new List<EventType>
            {
                new EventType { EventTypeName = "Trade Show" },
                new EventType { EventTypeName = "Conference" },
                new EventType { EventTypeName = "Enterpreneur" },
                new EventType { EventTypeName = "Holiday Parties" },
                new EventType { EventTypeName = "Appreciation Events" },
                new EventType { EventTypeName = "Charity Events" },
                new EventType { EventTypeName = "Board Meetings" },
                new EventType { EventTypeName = "Product Launches" },
                new EventType { EventTypeName = "Team Building Event" },
                new EventType { EventTypeName = "Sports Event" }
            };

            new List<Event>
            {
                new Event { Title = "Hirshberg Entrepreneurship Institute-ONLINE!", Description= "Offers a structured educational course",
                           StartDateTime = new DateTime(2020, 05, 11, 8, 0, 0), EndDateTime = new DateTime(2020, 09, 01, 17, 0, 0),
                           AvailableTickets = 10, MaxTickets = 10, EventType = eventTypes.Single(e => e.EventTypeName == "Enterpreneur"),
                           OrganizerName = "Gary Gary", City = "Online", OrganizerContactInfo = 099872928, State = "Online"},

                new Event { Title = "Trade Shows", Description= "Trade show 1",
                           StartDateTime = new DateTime(2020, 05, 11, 8, 0, 0), EndDateTime = new DateTime(2020, 09, 01, 17, 0, 0),
                           AvailableTickets = 10, MaxTickets = 10, EventType = eventTypes.Single(e => e.EventTypeName == "Enterpreneur"),
                           OrganizerName = "Gary Gary", City = "Online", OrganizerContactInfo = 099872928, State = "Online"}
            }.ForEach(e => context.Events.Add(e));

            context.SaveChanges();

        }
    }
}