using Blog_MVC.Entity.DbContext;
using Blog_MVC.Entity.Models;
using System.Linq;

namespace Blog_MVC.DAL.Repos
{
    public class AdminRepository
    {       
        public static Admin CheckUser(Admin admin)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Admin
                    .Where(a => a.UserName.Equals(admin.UserName) && a.Password.Equals(admin.Password))
                    .FirstOrDefault();
            }
        }
    }
}
