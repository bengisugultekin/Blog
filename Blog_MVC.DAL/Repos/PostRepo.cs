using Blog_MVC.Entity.DbContext;
using Blog_MVC.Entity.Models;
using Blog_MVC.Entity.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Blog_MVC.DAL.Repos
{
    public class PostRepo
    {
        public static List<ViewPost> GetAllForHome()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Post
                    .Where(p => p.IsDeleted == false)
                    .OrderByDescending(p => p.PostDate)
                    .Select(r => new ViewPost
                    {
                        PostID = r.PostID,
                        Title = r.Title,
                        PostDate = r.PostDate,
                        NameSurname = r.Admin.NameSurname

                    }).ToList();
            }
        }

        public static List<Post> GetAllForAdmin()
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Post
                    .OrderByDescending(p => p.PostDate)
                    .ToList();
            }
        }

        public static void Add(Post post)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                foreach (var itemTag in post.Tags)
                {
                    var result = db.Tag.Include("Posts").FirstOrDefault(t => t.Name == itemTag.Name);

                    if (result != null) //o tag den var demektir.
                    {
                        post.Tags = null; //cascade olarak eklemesin diye taglerini null yaptık ki tekrar post üzerinden bi daha eklemesin
                        result.Posts.Add(post); //var olan tag in post listesine yeni postu ekliyor
                    }
                    else //yani o tag den yok
                    {
                        itemTag.Posts = new List<Post>() { post }; //yeni tag'e yeni postu ekliyor
                        db.Tag.Add(itemTag); //tag tablosuna yeni tag i ekliyor
                    }
                }

                db.SaveChanges();
            }
        }

        public static ViewPost GetVM(int id)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Post.Include("Tags")
                    .Where(p => p.PostID == id)
                    .Select(p => new ViewPost
                    {
                        PostID = p.PostID,
                        Title = p.Title,
                        Content = p.Content,
                        PostDate = p.PostDate,
                        PictureUrl = p.PictureUrl,
                        AdminID = p.AdminID,
                        CategoryID = p.CategoryID,
                        CategoryName = p.Category.Name,
                        Tags = p.Tags
                    }).FirstOrDefault();
            }
        }

        public static Post GetPost(int id)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                return db.Post.Include("Tags").SingleOrDefault(p => p.PostID == id);
            }
        }


        public static List<Post> GetAllPostsByCategory(int id)
        {
            using (BlogDbContext db = new BlogDbContext())
            {

                return db.Post
                    .Where(p => p.CategoryID == id && p.IsDeleted == false)
                    .ToList();
            }
        }

        public static List<Post> GetAllPostsByTag(int tagID)
        {
            using (BlogDbContext db = new BlogDbContext())
            {

                return db.Tag.Include("Posts")
                    .SingleOrDefault(t => t.TagID == tagID)
                        .Posts.Where(p => p.IsDeleted == false)
                            .ToList();
            }
        }


        public static void UpdatePost(Post post)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                var _post = db.Post.Include("Tags").SingleOrDefault(p => p.PostID == post.PostID);

                _post.IsDeleted = true;
                db.SaveChanges();
                Add(post);


            }
        }

        public static void UpdateIsDeleted(Post post)
        {

            using (BlogDbContext db = new BlogDbContext())
            {
                var toBeUpdated = db.Post.Include("Tags").SingleOrDefault(p => p.PostID == post.PostID);

                toBeUpdated.IsDeleted = post.IsDeleted;

                db.SaveChanges();
            }
        }

    }
}
