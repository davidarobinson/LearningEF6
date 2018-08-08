using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
