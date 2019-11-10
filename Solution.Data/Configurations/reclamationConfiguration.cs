using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class reclamationConfiguration : EntityTypeConfiguration<reclamation>
    {
        public reclamationConfiguration()
        {
            HasOptional(r => r.Product).
                WithMany(p => p.reclamations).
                HasForeignKey(r => r.ProductId).
                WillCascadeOnDelete(false);

        }
    }
}
