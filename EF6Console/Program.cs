using EF6Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {



            using (var a = new DotnetableDbContext())
            {
                //var user = new User
                //{
                //    UserID = Guid.NewGuid(),
                //    Forename = "John",
                //    Surname = "Jones",
                //};

                //var post = new Post
                //{
                //    Title = "",
                //    PostID = Guid.NewGuid(),
                //    User=user
                //};
                //a.Posts.Add(post);
                //a.SaveChanges();

                var posts = a.Posts;
                Console.WriteLine(posts.Count());

            }
        }
    }
}
