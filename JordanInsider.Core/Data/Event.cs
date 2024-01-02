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

        public string? Name { get; set; }

        public decimal Eventid { get; set; }
        public string? Datestart { get; set; }
        public string? Details { get; set; }
        public string? location { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Validity { get; set; }
        public void SetImages(List<string> imagess)
        {
            if (imagess.Count >= 1)
            {
                Image1 = imagess[0];
            }

            if (imagess.Count >= 2)
            {
                Image2 = imagess[1];
            }

         


        }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
