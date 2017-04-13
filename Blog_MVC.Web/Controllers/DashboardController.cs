using Blog_MVC.DAL.Repos;
using Blog_MVC.Entity.Models;
using Blog_MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog_MVC.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ViewBag.Header = "Panel";
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "Login");
            }

        }

        public ActionResult AddPost(int? id)
        {
            if (Session["username"] != null)
            {
                if (!id.HasValue)
                {
                    ViewBag.Header = "Add Post";
                    return View();
                }
                else
                {
                    ViewBag.Header = "Update Post";

                    var post = PostRepo.GetVM((int)id);

                    return View(post);
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Login");
            }


        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddPost(ViewForAddPost model)
        {
            #region Tags and Category
            string[] tags = model.Tags.Split(',');

            List<Tag> tagsList = new List<Tag>();

            foreach (var item in tags)
            {
                tagsList.Add(new Tag { Name = item });
            }


            int catID;

            CategoryRepository.Add(new Category { Name = model.CategoryName });
            catID = CategoryRepository.Get(model.CategoryName).CategoryID;

            #endregion

            Post post = new Post()
            {
                Title = model.Title,
                PostDate = DateTime.Now,
                PictureUrl = model.PictureUrl,
                Content = model.Content,
                Tags = tagsList,
                CategoryID = catID,
                AdminID = 1,
            };

            if (model.PostID == 0) //yeni post eklemeli
            {
                PostRepo.Add(post);
            }
            else //güncelleme yapmalı
            {
                post.PostID = model.PostID;
                PostRepo.UpdatePost(post);
            }
            return RedirectToAction("ListPost", "Dashboard");
        }

        public ActionResult ListPost()
        {
            if (Session["username"] != null)
            {
                ViewBag.Header = "All Posts";
                return View(PostRepo.GetAllForAdmin());
            }
            else
            {
                return RedirectToAction("SignIn", "Login");
            }

        }


        public ActionResult DeletePost(int id)
        {
            var post = PostRepo.GetPost(id);
            post.IsDeleted = true;
            PostRepo.UpdateIsDeleted(post);

            return RedirectToAction("ListPost", "Dashboard");
        }

        public ActionResult AddPostBack(int id)
        {
            var post = PostRepo.GetPost(id);
            post.IsDeleted = false;
            PostRepo.UpdateIsDeleted(post);

            return RedirectToAction("ListPost", "Dashboard");
        }


    }
}