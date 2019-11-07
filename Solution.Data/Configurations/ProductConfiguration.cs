using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations 
{
   public class ProductConfiguration : EntityTypeConfiguration<Product>
    {

        public ProductConfiguration()
        {
           /* HasRequired(x => x.offer)
        .WithMany(x => x.Products)
     .HasForeignKey(x => x.ProductId);*/
            HasRequired(Prod => Prod.offer).WithMany(o => o.Products)
                .HasForeignKey(Prod => Prod.OfferId).WillCascadeOnDelete(false);

            

        }


    }
}
