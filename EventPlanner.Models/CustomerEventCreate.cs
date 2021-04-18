using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class CustomerEventCreate
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
