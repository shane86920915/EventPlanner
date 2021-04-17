using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class EventSponsor
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }


        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Sponsor))]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
