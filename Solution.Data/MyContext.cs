using Solution.Data.Configurations;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {

        public MyContext() : base("name=MaChaine")
        {

        }
        //dbset<>
        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Pack> Packs { get; set; }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Resources> Resources { get; set; }


        public DbSet<reclamation> reclamations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //config + costumconventions
            //modelBuilder.Configurations.Add();
            //modelBuilder.Conventions.Add();

            modelBuilder.Configurations.Add(new ProductConfiguration());
           

        }

    }
}
