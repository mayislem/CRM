using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Solution.Domain.Entities
{
    public class Pack
    {
        [Key]
        public int PackId { get; set; }
        public String TypePack { get; set; }
        public String PackName { get; set; }
        public String Description { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProductId { get; set; }

        public virtual ICollection<ProductPack> productpack { get; set; }


    }
}
