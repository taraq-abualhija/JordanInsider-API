using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class User
    {
        public decimal Userid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phonenum { get; set; }
        public decimal? Roleid { get; set; }
        public string? Password { get; set; }
        public string? Imagename { get; set; }
    }
}
