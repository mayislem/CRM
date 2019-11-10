using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Order
    {
        [Key]
        [Column(Order=1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        [DataType(DataType.Date)]
        
        public DateTime OrderDate { get; set; }
        public int ProductQuantity { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
