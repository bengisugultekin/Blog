using Blog_MVC.Entity.DbContext;
using Blog_MVC.Entity.Models;

namespace Blog_MVC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BlogDbContext
            //using (BlogDbContext db = new BlogDbContext())
            //{
            //    #region Test

            //    //Admin adm = new Admin();
            //    //adm.UserName = "bngs";
            //    //adm.Password = "1234";
            //    //db.Admin.Add(adm);

            //    //Category cat = new Category();
            //    //cat.Name = "OOP";
            //    //db.Category.Add(cat);

            //    //Post p1 = new Post()
            //    //{
            //    //    Title = "Title 1",
            //    //    Content = "Content will be here soon...",
            //    //    PostDate = DateTime.Now,
            //    //    AdminID = 1,
            //    //    CategoryID = 1,

            //    //};

            //    //Post p2 = new Post()
            //    //{
            //    //    Title = "Title 2",
            //    //    Content = "Content will be here soon...",
            //    //    PostDate = DateTime.Now,
            //    //    AdminID = 1,
            //    //    CategoryID = 1,

            //    //};

            //    //Post p3 = new Post()
            //    //{
            //    //    Title = "Title 3",
            //    //    Content = "Content will be here soon...",
            //    //    PostDate = DateTime.Now,
            //    //    AdminID = 1,
            //    //    CategoryID = 1,

            //    //};

            //    //db.Post.Add(p1);
            //    //db.Post.Add(p2);
            //    //db.Post.Add(p3);

            //    //Tag tag1 = new Tag()
            //    //{
            //    //    Name = "Asp.Net MVC",
            //    //    Posts = new List<Post>()
            //    //    {
            //    //        p1,
            //    //        p2
            //    //    }
            //    //};

            //    //Tag tag2 = new Tag()
            //    //{
            //    //    Name = "C#",
            //    //    Posts = new List<Post>()
            //    //    {
            //    //        p3
            //    //    }
            //    //};

            //    //db.Tag.Add(tag1);
            //    //db.Tag.Add(tag2);

            //    #endregion

            //    //Post p = new Post()
            //    //{
            //    //    AdminID = 1,
            //    //    CategoryID = 1,
            //    //    Title = "Title 4",
            //    //    Content = "content will be here soon...",
            //    //    PostDate = DateTime.Now,

            //    //    //yeni tag oluşturduk
            //    //    //Tags = new List<Tag>
            //    //    //{
            //    //    //    new Tag { Name = "Tag1" },
            //    //    //    new Tag { Name = "Tag1" }
            //    //    //}

            //    //    Tags = db.Tag.Where(t => t.Name == "Asp.Net MVC" || t.Name == "C#").ToList(),

            //    //};

            //    //db.Post.Add(p);
            //    //db.SaveChanges();

            //}
            #endregion

            #region database olusturma
            //Category cat = new Category();
            //cat.Name = "OOP";
            //CategoryRepository.Add(cat);

            //Admin adm = new Admin();
            //adm.UserName = "bngs";
            //adm.Password = "1234";
            //AdminRepository.Add(adm);

            //Post p = new Post()
            //{
            //    AdminID = 1,
            //    CategoryID = 1,
            //    Title = "Title 3",
            //    Content = "Content will be here soon...",
            //    PostDate = DateTime.Now,


            //    //yeni tag oluşturduk
            //    Tags = new List<Tag>
            //    {
            //        new Tag { Name = "C#" },
            //        new Tag { Name = "MVC" }
            //    }
            //};

            //PostRepo.Add(p);
            #endregion

            #region Tag'e göre post getirme
            ////tag e tıklandı tagId im var 

            //var result = PostRepo.GetAllPostsByTag(1);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}
            #endregion

            #region kullanıcı ekleme

            //using (BlogDbContext db = new BlogDbContext())
            //{                

            //    Admin adm = new Admin();
            //    adm.UserName = "Bengisu";
            //    adm.Password = "1234";
            //    adm.NameSurname = "Bengisu Gültekin";                
            //    db.Admin.Add(adm);
            //}

            #endregion


        }
    }
}
