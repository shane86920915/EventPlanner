using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class CustomerEvent
    {
      
  

        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public  virtual Customer Customer { get; set; }


        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Event))]
        public int EventId {get; set; }
        public virtual Event Event { get; set; }
    }
}
