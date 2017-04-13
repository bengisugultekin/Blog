using Blog_MVC.Entity.DbContext;
using Blog_MVC.Entity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog_MVC.DAL.Repos
{
    public class CategoryRepository
    {
        public static List<Category> GetAll()
        {
            using (BlogDbContext db = new BlogDbContext())
            {

                return db.Category
                    .Where(c => c.IsDeleted == false)
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }

        public static Category Get(string categoryName)  
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Category.FirstOrDefault(c => c.Name == categoryName);
            }
        }

        public static Category Get(int id)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Category.Include("Posts").SingleOrDefault(c => c.CategoryID == id);
            }
        }

        public static void Add(Category newCategory)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                if (db.Category.FirstOrDefault(c => c.Name == newCategory.Name) == null)
                {
                    db.Category.Add(newCategory);
                    db.SaveChanges();
                }
                
            }
        }

        


    }
}
