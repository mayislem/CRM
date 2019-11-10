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
    public class OrderService : Service<Order>, IOrderService
    {
        private MyContext db = new MyContext();

        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);

        public OrderService() : base(UTK)
        {

        }
        public IEnumerable<Order> GetOrderByProduct(int IdProduct)
        {
            return GetMany(o => o.ProductId == IdProduct);
        }

        public List<Product> GetProdbyId()
        {
            return db.Products.ToList();
        }

        public Order getbyids(int productId, int userId)
        {
            return db.Orders.Where(o => o.ProductId == productId && o.UserId == userId).SingleOrDefault();
            
        }
    }
}
