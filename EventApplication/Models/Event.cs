using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event title is required")]
        [StringLength(50, ErrorMessage = "Title should not exceed 50 characters")]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage = "Description should not exceed 150 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Start Date and Time is required")]
        [DisplayName("Start Date and Time")]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "Event End Date and Time is required")]
        [DisplayName("End Date and Time")]
        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Organizer Name is required")]
        [DisplayName("Organizer")]
        public string OrganizerName { get; set; }

        [DisplayName("Organizer Contact Info")]
        public int OrganizerContactInfo { get; set; }

        [Required(ErrorMessage = "Maximum Number of Tickets is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Max Tickets cannot be 0")]
        [DisplayName("Max Tickets")]
        public int MaxTickets { get; set; }

        [Required(ErrorMessage = "Available Number of Tickets is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Available Tickets cannot be 0")]
        [DisplayName("Available Tickets")]
        public int AvailableTickets { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [DisplayName("Event Type")]
        public Nullable<int> EventTypeID { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual ICollection<TicketOrder> TicketOrders { get; set; }
    }
}