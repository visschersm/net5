using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseSqlite("Data Source=blogging.db")
                .EnableSensitiveDataLogging()
                .Options;

            using(var context = new BloggingContext(options))
            {
                Console.WriteLine("Inserting a new blog");
                context.Add(new Blog { Url = "https://devblogs.microsoft.com/dotnet/announcing-entity-framework-core-ef-core-5-0-preview-8" });
                context.SaveChanges();

                Console.WriteLine("Querying for a blog");
                var blog = context.Blogs.AsNoTracking()
                    .OrderBy(blog => blog.Id)
                    .First();

                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post
                {
                    Title = "Hello World",
                    Content = "I am writing some dotnet 5 console applications!"
                });
                context.SaveChanges();

                Console.WriteLine("Delete the blog");
                context.Remove(blog);
                context.SaveChanges();
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base() 
        {

        }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
            
        }

         public DbSet<Blog> Blogs { get; set; }
         public DbSet<Post> Posts { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasKey(blog => blog.Id);

            modelBuilder.Entity<Post>()
                .HasKey(post => post.Id);
        }
    }

    public class Blog 
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
