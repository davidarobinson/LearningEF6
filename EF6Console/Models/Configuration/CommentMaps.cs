using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models.Configuration
{
    public class CommentMaps : EntityTypeConfiguration<Comment>
    {
        public CommentMaps()
        {
            Property(p => p.Email).HasMaxLength(50);
            Property(p => p.Name).HasMaxLength(200);
        }
    }
}
