using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventDetails
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        [MaxLength(70, ErrorMessage = "No more than 70 characters allowed.")]
        [MinLength(2, ErrorMessage = "Enter at least 2 characters.")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event Price")]
        public decimal Price { get; set; }

        public string Address { get; set; }
       
        public string City { get; set; }
      
        public string State { get; set; }
        public List<int> CustomerId { get; set; }
        public List<string> CustomerFName { get; set; }
        public List<string> CustomerLName { get; set; }
        // public virtual List<CustomerListItem> Customer { get; set; }
        public virtual  List<int> SponsorId { get; set; }
        public virtual List<int> SpeakerId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
