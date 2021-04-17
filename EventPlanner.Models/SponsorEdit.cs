using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class SponsorEdit
    {
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

    }
}
