using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class SpeakerDetails
    {
        [Key]
        [Display(Name = "Motivational Speaker ID")]
        public int SpeakerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string SpeakerFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string SpeakerLName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
