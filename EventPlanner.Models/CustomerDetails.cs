using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
     public class CustomerDetails
    {
        [Display(Name ="Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name ="First Name")]
        public string CustomerFName { get; set; }

         [Display(Name ="Last Name")]
        public string CustomerLName { get; set; }

        [MaxLength(1, ErrorMessage = "Only one character allowed")]
        [Display(Name = "Middel Initial")]
        public string CustomerMInitial { get; set; }


        public string Address { get; set; }

  
        public string City { get; set; }

      
        public string State { get; set; }

         [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public List<int> EventId { get; set; }

   
        public List<EventListItem> Event { get; set; }










    }
}
