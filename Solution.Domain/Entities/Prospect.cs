using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Prospect
    {
        [Key]
        public int ProspectId { get; set; }
        public string ProspectName { get; set; }
        public string Address { get; set; }
    }
}
