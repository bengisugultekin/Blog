using Blog_MVC.DAL.Repos;
using Blog_MVC.Web.Models;
using PagedList;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog_MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page)
        {
            var result = PostRepo.GetAllForHome();
            return View(result.ToPagedList(page ?? 1, 3));
        }

        public ActionResult PostDetail(int id)
        {
            return View(PostRepo.GetVM(id));
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Contact(Mail mail)
        {
            var client = new SendGridClient("api-key");
            var from = new EmailAddress(mail.Email, mail.Name);
            var subject = "Contact Page";
            var to = new EmailAddress("bengisugultekin@gmail.com", "Bengisu Gültekin");
            var plainTextContent = "The Message from Blog Contact Page";
            var htmlContent =
                mail.Message
                + "<strong> Phone : " + mail.Phone + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return View();

        }

        public ActionResult Search()
        {
            ViewBag.Categories = CategoryRepository.GetAll();
            ViewBag.Tags = TagRepository.GetAll();
            return View();
        }

        public ActionResult SearchByTag(int id, int? page)
        {
            ViewBag.Subheading = "by tag:" + TagRepository.Get(id).Name;
            return View("SearchResults", PostRepo.GetAllPostsByTag(id).ToPagedList(page ?? 1, 3));
        }


        public ActionResult SearchByCategory(int id, int? page)
        {
            ViewBag.Subheading = "The Posts of " + CategoryRepository.Get(id).Name + " Category";
            return View("SearchResults", PostRepo.GetAllPostsByCategory(id).ToPagedList(page ?? 1, 3));
        }




    }
}