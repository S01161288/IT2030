
using System;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class TicketOrder
    {
        public TicketOrder() => DateOrdered = DateTime.Now;
        [Key]
        public int OrderNumber { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int NumberOfTicket { get; set; }
        public string Status { get; set; }
        public DateTime DateOrdered { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}