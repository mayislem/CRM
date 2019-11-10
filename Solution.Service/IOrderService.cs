using Solution.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IOrderService : IService<Order>
    {
        IEnumerable<Order> GetOrderByProduct(int IdProduct);
        List<Product> GetProdbyId();
        Order getbyids(int productId, int userId);
    }
}
