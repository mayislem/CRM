using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Forum
    {
        [Key]
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date_Pub { get; set; }
        [ForeignKey("CommentId")]
        public virtual ICollection<Comment> Comments { get; set; }
        public ICollection<object> Forums { get; internal set; }
    }
}
