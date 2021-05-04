using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Customer 
    {
        [Required]
        public Guid OwnerId { get; set; }

        [Key]
        [Display(Name ="Customer ID")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string CustomerFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string CustomerLName { get; set; }

        [MaxLength(1, ErrorMessage ="Only one character allowed")]
        [Display (Name ="Middel Initial")]
        public string CustomerMInitial { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        
        [ForeignKey(nameof(Event))]
        public virtual int EventId { get; set; }
        public virtual string EventTitle { get; set; }
        public virtual Event Event { get; set; }

        //[ForeignKey(nameof(Event))]
        //public virtual Event Events { get; set; }
    }
}
