using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Entities
{
    public class User
    {
        public User()
        {
            
            this.Clients = new List<Client>();
            this.Agents = new List<Agent>();
            this.Prospects = new List<Prospect>();
        }
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual ICollection<Client> Clients { get; set; }
        public int? AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual ICollection<Agent> Agents { get; set; }
        public int? ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual ICollection<Prospect> Prospects { get; set; }
        public ICollection<object> Users { get; internal set; }
    }
}
