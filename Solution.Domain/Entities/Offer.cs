using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public float Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImgUrl { get; set; }

        public string Description { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ICollection<Product> Products { get; set; }

    }
}
