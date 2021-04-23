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
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        
        public decimal Price { get; set; }

        public string Address { get; set; }
       
        public string City { get; set; }
      
        public string State { get; set; }
        public virtual List<CustomerListItem> Customer { get; set; }
        public virtual  List<int> SponsorId { get; set; }
        public virtual List<int> SpeakerId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
