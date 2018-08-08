using EF6Console.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console.Models
{
    public class DotnetableDbContext :DbContext
    {
        public DotnetableDbContext():base("DBConn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DotnetableDbContext, Migrations.Configuration>());

        }

        public DbSet<Post> Posts{ get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>()             // Starting with the Post entity
            //    .HasRequired<User>(u => u.Author)   // For a post to exist A user is required first
            //    .WithMany(p => p.Posts)             // The User may have many Post Entities
            //    .HasForeignKey(u => u.AuthorID);    // The post is linked via AuthorID property

            //modelBuilder.Entity<Post>()             // Starting with the Post entity
            //    .HasMany<Tag>(p => p.Tags)          // A post entity may have tag entities related
            //    .WithMany(t => t.Posts)             // The tag entity themselves may have many post entities related
            //    .Map(pt =>                          
            //    {                                   // To map the relationship
            //        pt.MapLeftKey("PostID");        // Link the posts via postid
            //        pt.MapRightKey("TagID");        // to the tag entity via tagid
            //        pt.ToTable("PostTag");          // In a table called PostTag
            //    });

            //modelBuilder.Configurations.Add(new PostMap());

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(type => !String.IsNullOrEmpty(type.Namespace))
                 .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                      && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
