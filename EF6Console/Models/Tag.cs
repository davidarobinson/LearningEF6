using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models
{
    public class Tag
    {
        public Guid TagID { get; set; }
        public string Name { get; set; }

        public bool Deleted { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
