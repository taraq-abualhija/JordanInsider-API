using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class Event
    {
        public Event()
        {
            Tickets = new HashSet<Ticket>();
        }

        public decimal Eventid { get; set; }
        public DateTime? Datestart { get; set; }
        public string? Details { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public DateTime? Validity { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
