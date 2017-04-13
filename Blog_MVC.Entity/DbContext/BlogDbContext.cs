namespace Blog_MVC.Entity.DbContext
{
    using Models;
    using System.Data.Entity;

    public class BlogDbContext : DbContext
    {

        public BlogDbContext()
            : base("name=BlogDb")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public class Configuration : CreateDatabaseIfNotExists<BlogDbContext>
        {
            protected override void Seed(BlogDbContext context)
            {
                context.Admin.Add(new Admin()
                {
                    NameSurname = "Bengisu Gültekin",
                    UserName = "{username}",
                    Password = "{password}"
                });

                context.SaveChanges();
            }
        }
    }


}