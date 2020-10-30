using System;
using System.Drawing;

namespace TourOfHeroes.Core.Entity
{
    public class Photo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public String Colour { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
