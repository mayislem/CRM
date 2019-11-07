using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class ProductPack
    {
        [Key]
        [Column(Order=1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PackId { get; set; }

        public virtual Product product { get; set; }
        public virtual Pack pack { get; set; }


    }
}
