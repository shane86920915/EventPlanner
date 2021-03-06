using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Sponsor 
    {
        [Required]
        public Guid OwnerId { get; set; }

        [Key]
        [Display(Name ="Sponsor ID")]
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

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<EventSponsor> Events { get; set; }


    }
}
