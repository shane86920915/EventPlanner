using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventEdit
    {
        public int EventId { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "No more than 70 characters allowed" )]
        [MinLength(2, ErrorMessage ="Enter at least 2 characters")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event Price")]
        public decimal Price { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        public string City { get; set; }


        [Required]
        public string State { get; set; }


    }
}
