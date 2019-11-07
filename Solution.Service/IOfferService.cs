using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IOfferService : IService<Offer>
    {
        IEnumerable<Offer> GetProductByOffer(int IdOffer);
        List<Product> GetTtireId();
        List<Offer> GetOfferssearch(string search,string date);
        bool compare(DateTime dt1, string dt2);
        List<Offer> Getofferbyname(string name);

    }
}
