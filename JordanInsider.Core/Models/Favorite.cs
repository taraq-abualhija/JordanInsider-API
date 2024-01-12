using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class Favorite
    {
        public decimal Favoriteid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Touristsiteid { get; set; }
    }
}
