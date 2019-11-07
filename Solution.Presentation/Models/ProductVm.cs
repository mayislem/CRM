using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ProductVm
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public float Price { get; set; }
        public String ImageUrl { get; set; }
        public long Quantity { get; set; }
        public string Category { get; set; }

    }
}