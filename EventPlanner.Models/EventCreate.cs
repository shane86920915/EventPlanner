using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventCreate
    {
        [Display(Name = "Event Title")]
        [Required]
        [MaxLength(70, ErrorMessage = "No more than 70 characters allowed.")]
        [MinLength(2, ErrorMessage = "Enter at least 2 characters.")]
        public string EventTitle { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
       




    }
}
