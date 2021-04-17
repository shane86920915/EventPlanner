using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        public string CustomerFName { get; set; }


        public string CustomerLName { get; set; }

        public char? CustomerMInitial { get; set; }


        public string Address { get; set; }


        public string City { get; set; }

        public string State { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }













    }
}
