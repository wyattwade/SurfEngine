using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurfboardsMVP.Models
{
    public class Surfboard
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Shape { get; set; }
        public int? Height { get; set; }
        public double Width { get; set; }
        public double Volume { get; set; }
        public int Price { get; set; }
        public int Zip { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Email { get; set; }
        public bool FromInternalUser { get; set; }
        public int TotalRows { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
    }
}