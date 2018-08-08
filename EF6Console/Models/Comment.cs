using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models
{
    public class Comment
    {
        public Comment()
        {
            Approved = false;
        }

        public Guid CommentID { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }

        // Name/Nickname
        public string Name { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApprovedOn { get; set; }

        public Guid PostID { get; set; }
        public Post Post { get; set; }
    }
}
