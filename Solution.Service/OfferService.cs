using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Domain.Entities;
using System.Linq.Expressions;
using Solution.Data.Infrastructure;
using Solution.Data;
using System.Globalization;

namespace Solution.Service
{
    public class OfferService : Service<Offer>, IOfferService
    {

        private MyContext db = new MyContext();

        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public OfferService() : base(UTK)
        {

        }

        public IEnumerable<Offer> GetProductByOffer(int IdOffer)
        {
            return GetMany(o => o.OfferId == IdOffer);

        }

        public List<Product> GetTtireId()
        {
            return db.Products.ToList();
          
        }
        public List<Offer> Getofferbyname(string name)
        {

           

                students = students.Where(s => s.OfferName.Contains(name));

           


            return students.ToList();

        }

        public bool compare(DateTime dt1, string dt2)
        {

           /* DateTime dt2 = DateTime.ParseExact(date31strin, 
                        "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture);*/


            string date1 = dt1.ToString();
            Console.WriteLine(date1);
            if (date1.CompareTo(dt2) == 0)
                return true;
            else
            return false;
        }

        public List<Offer> GetOfferssearch(string search,string date)
        {
            //DateTime dt = DateTime.ParseExact(s, "0:yyyy-MM-dd", CultureInfo.InvariantCulture);

           /*DateTime date1 = DateTime.ParseExact(date,
                         "yyyy-MM-dd", CultureInfo.InvariantCulture);*/
            var students = from s in db.Offers
                           select s;
            


            return students.ToList();


        }


      




    }
}
