using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        MyContext db = new MyContext();
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);

        public ProductService() : base(UTK)
        {

        }

        public IEnumerable<Product> GetProductById(int IdProduct)
        {
            return GetMany(p => p.ProductId == IdProduct);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }
    }
}
