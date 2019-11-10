using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public float Price { get; set; }
        public String ImageUrl { get; set; }
        public long Quantity { get; set; }
        public string Category { get; set; }

        public virtual ICollection<reclamation> reclamations { get; set; }

    }
}
