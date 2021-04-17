using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class SponsorDetails
    {
        [Key]
        [Display(Name = "Sponsor ID")]
        public int SponsorId { get; set; }

        [Display(Name = "Corporate Sponsor")]
        [Required]
        [Range(2, 70, ErrorMessage = "Enter at least 2 caracters and no more than 70.")]
        public string SponsorsName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        public virtual List<Event> EventId  { get; set; }
        public virtual List<Event> EventTitle { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
