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
        [Range(2, 70, ErrorMessage = "Enter at least 2 caracters and no more than 70.")]
        public string EventTitle { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        public string City { get; set; }


        [Required]
        public string State { get; set; }


    }
}
