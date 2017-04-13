using Blog_MVC.DAL.Repos;
using Blog_MVC.Entity.Models;
using System.Web.Mvc;

namespace Blog_MVC.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Admin admin)
        {
            var result = AdminRepository.CheckUser(admin);

            if (result != null) //username ve password doğru
            {
                Session["username"] = admin.UserName;
                Session["password"] = admin.Password;
                return RedirectToAction("Index", "Dashboard");
            }
            else //ikisinden biri yanlış ya da ikisi de yanlış
            {
                ViewBag.Message = "Login failed. Check your login details!";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("SignIn", "Login");
        }
    }
}