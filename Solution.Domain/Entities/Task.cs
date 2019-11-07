using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public ICollection<object> Tasks { get; internal set; }
    }
}
