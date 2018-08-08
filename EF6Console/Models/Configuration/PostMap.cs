using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models.Configuration
{
    public class PostMap: EntityTypeConfiguration<Post> 
    {
        public PostMap()
        {
            //modelBuilder.Entity<Post>()             // Starting with the Post entity
            HasRequired<User>(u => u.Author)   // For a post to exist A user is required first
            .WithMany(p => p.Posts)             // The User may have many Post Entities
            .HasForeignKey(u => u.AuthorID);    // The post is linked via AuthorID property

            //modelBuilder.Entity<Post>()             // Starting with the Post entity
            HasMany<Tag>(p => p.Tags)          // A post entity may have tag entities related
            .WithMany(t => t.Posts)             // The tag entity themselves may have many post entities related
            .Map(pt =>
            {                                   // To map the relationship
                pt.MapLeftKey("PostID");        // Link the posts via postid
                pt.MapRightKey("TagID");        // to the tag entity via tagid
                pt.ToTable("PostTag");          // In a table called PostTag
            });

            Property(p => p.Title).HasMaxLength(250);
            Property(p => p.URL).HasMaxLength(250);
            Property(p => p.Status).HasMaxLength(20);

        }
    }
}
