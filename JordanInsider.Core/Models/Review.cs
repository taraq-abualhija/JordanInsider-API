using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Models
{
    public partial class Review
    {
        public decimal Reviewid { get; set; }
        public decimal? Touristsiteid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Rating { get; set; }
        public string? Reviewtxt { get; set; }
        public DateTime? Reviewdate { get; set; }
    }
}
