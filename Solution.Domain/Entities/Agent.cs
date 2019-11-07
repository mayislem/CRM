using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string Type { get; set; }
        public int? TasktId { get; set; }
        [ForeignKey("TaskId")]
        
        public ICollection<object> Agents { get; internal set; }
        
    }
}
