using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Event
    {
        [Required]
        public Guid OwnerId { get; set; }

        [Key]
        [Display(Name ="Event ID")]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        [MaxLength(70, ErrorMessage = "No more than 70 characters allowed.")]
        [MinLength(2, ErrorMessage ="Enter at least 2 characters.")]
        public string EventTitle { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City  { get; set; }

        [Required]
        public string State { get; set; }
        
        [Required]
        [Display(Name ="Event Price")]
        public decimal Price { get; set; }
        public virtual List<Customer> Customers { get; set; }

        

        public virtual ICollection<EventSpeaker> Speakers { get; set; } = new List<EventSpeaker>();

        public virtual ICollection<EventSponsor> Sponsors { get; set; } = new List<EventSponsor>(); 



        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }



        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
