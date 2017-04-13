using Blog_MVC.Entity.DbContext;
using Blog_MVC.Entity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog_MVC.DAL.Repos
{
    public class TagRepository
    {
        public static List<Tag> GetAll()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Tag
                    .Where(t => t.IsDeleted == false)
                    .OrderBy(t => t.Name)
                    .ToList();
            }
        }

        public static Tag Get(int id)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Tag.Include("Posts").SingleOrDefault(t => t.TagID == id);
            }
        }

        public static Tag Get(string name)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Tag.SingleOrDefault(t => t.Name == name);
            }
        }

        

    }
}
