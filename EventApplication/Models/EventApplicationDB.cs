using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class EventApplicationDB : DbContext
    {
        public EventApplicationDB()
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}