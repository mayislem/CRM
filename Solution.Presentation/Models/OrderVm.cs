using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class OrderVm
    {
    
        
        public int ProductId { get; set; }
        
        public int UserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int ProductQuantity { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        public float Price { get; set; }
        public float TotalPrice()
        { return ProductQuantity * Price; }
    }
}