using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
            Tickets = new HashSet<Ticket>();
        }

        public decimal Userid { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phonenum { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
