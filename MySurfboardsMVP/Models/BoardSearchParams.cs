using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurfboardsMVP.Models
{
    public class BoardSearchParams
    {
        public string Location { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MinWidth { get; set; }
        public int? MaxWidth { get; set; }
        public int? MinHeight { get; set; }
        public int? MaxHeight { get; set; }
        public int? MinVolume { get; set; }
        public int? MaxVolume { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? CurrentPage { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}