using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.DTO
{
    public class ReviewUserDTO
    {
        public string? Name { get; set; }
        public string? Imagename { get; set; }
        public decimal? Rating { get; set; }
        public string? Reviewtxt { get; set; }
        public DateTime? Reviewdate { get; set; }


    }
}
