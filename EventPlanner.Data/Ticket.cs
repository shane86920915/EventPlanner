using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Ticket
    {
        [Key]
        [Display(Name = "Ticket ID")]
        public int TicketId { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        [Display(Name ="Date of Transaction")]

        public DateTimeOffset CreatedUtc { get; set; }


    }
}
