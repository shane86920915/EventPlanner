using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string CustomerFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string CustomerLName { get; set; }
        [Required]
        [MaxLength(1, ErrorMessage = "Only one character allowed")]
        [Display(Name = "Middel Initial")]
        public string CustomerMInitial { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }


       
        public int EventId { get; set; }
       

       
    }
}

