using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace JordanInsider.Core.Models
{
    public partial class Touristsite
    {
        public Touristsite()
        {
            Reviews = new HashSet<Review>();
        }

        public decimal Touristsiteid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? status { get; set; }
        public string? location { get; set; }
        public string? tfrom { get; set; }
        public string? tto { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }

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

            if (imagess.Count >= 3)
            {
                Image3 = imagess[2];
            }

            if (imagess.Count >= 4)
            {
                Image4 = imagess[3];
            }



        }
    }
}
