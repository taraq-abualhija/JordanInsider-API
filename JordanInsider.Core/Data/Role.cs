using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
