using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class EventType
    {
        [Key]
        [DisplayName("Event Type")]
        public int EventTypeID { get; set; }

        [StringLength(50, ErrorMessage = "Type should not exceed 50 characters")]
        [DisplayName("Type")]
        public string EventTypeName { get; set; }
    }
}