using Service.Pattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
  
    public class reclamationService : Service<reclamation>, IreclamationService
    {
        private MyContext db = new MyContext();

        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public reclamationService() : base(UTK)
        {

        }

        public IEnumerable<reclamation> GetProductByReclamation(int Idrec)
        {
            return GetMany(o => o.Idrec == Idrec);
        }




        public List<reclamation> GetReclamationsearch(string search, string date)
        {
            //DateTime dt = DateTime.ParseExact(s, "0:yyyy-MM-dd", CultureInfo.InvariantCulture);

            /*DateTime date1 = DateTime.ParseExact(date,
                          "yyyy-MM-dd", CultureInfo.InvariantCulture);*/
            var students = from s in db.reclamations
                           select s;
            if (!String.IsNullOrEmpty(search) && !String.IsNullOrEmpty(date))
            {

                DateTime date1 = Convert.ToDateTime(date);

                students = students.Where(s => s.etat.Contains(search)
                && s.date == date1);

            }


            return students.ToList();


        }
    }
}
