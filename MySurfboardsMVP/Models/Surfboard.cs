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
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Volume { get; set; }
    }
}