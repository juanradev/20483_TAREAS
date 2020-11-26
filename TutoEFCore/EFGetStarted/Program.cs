using System;
using static  System.Console;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Create
                 WriteLine("Inserting a new blog");
                ///db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                 db.Add(new Blog { Url = "http://blogs.msdn.com/segundo" });
                
                db.SaveChanges();
                Presskey();

                // Read
                WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
                WriteLine ($"Primer blog;{blog.Url}");
                Presskey();
                // Update
                WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();
Presskey();
                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
                Presskey();
            }
        }
   
    static void Presskey()
    {
        WriteLine("press ");
        ReadKey();
    }
   
    }


   
}