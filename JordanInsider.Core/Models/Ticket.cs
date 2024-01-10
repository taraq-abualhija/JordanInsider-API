using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class Ticket
    {
        public decimal Ticketid { get; set; }
        public decimal? Eventid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Price { get; set; }
    }
}
