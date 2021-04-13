﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Event
    {
        [Key]
        [Display(Name ="Event ID")]
        public int EventId { get; set; }

        [Display(Name = "Event Title")]
        [Required]
        [Range (2, 70, ErrorMessage = "Enter at least 2 caracters and no more than 70.")]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City  { get; set; }

        [Required]
        public string State { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
