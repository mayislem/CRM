using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IreclamationService : IService<reclamation>
    {
        IEnumerable<reclamation> GetProductByReclamation(int Idrec);

        List<reclamation> GetReclamationsearch(string search, string date);
    }
}
