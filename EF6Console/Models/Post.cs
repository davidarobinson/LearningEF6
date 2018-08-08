using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models
{
    public class Post
    {
        public Guid PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishOn { get; set; }
        public string Status { get; set; }
        public string URL { get; set; }

        public User Author { get; set; }

        public Guid AuthorID { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
