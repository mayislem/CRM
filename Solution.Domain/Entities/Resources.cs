using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Resources
    {
        [Key]
        public int ResourceId { get; set; }
        public string TypeResource { get; set; }
        public DateTime Date_Location { get; set; }
    }
}
