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
        
        public int CustomerId { get; set; }
    
        public string CustomerFName { get; set; }

       
        public string CustomerLName { get; set; }

        [MaxLength(1, ErrorMessage = "Only one character allowed")]
        [Display(Name = "Middel Initial")]
        public string CustomerMInitial { get; set; }


        public string Address { get; set; }

  
        public string City { get; set; }

      
        public string State { get; set; }

      
        public DateTimeOffset CreatedUtc { get; set; }

        
        public DateTimeOffset? ModifiedUtc { get; set; }

        public List<int> EventId { get; set; }

        public List<string> EventTitle { get; set; }










    }
}
