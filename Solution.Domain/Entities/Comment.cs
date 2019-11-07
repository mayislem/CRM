using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int? ForumId { get; set; }
        [ForeignKey("ForumId")]
        public ICollection<object> Comments { get; internal set; }
        public ICollection<object> Forums { get; internal set; }
    }
}
