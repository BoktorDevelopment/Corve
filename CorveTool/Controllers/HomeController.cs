using CorveTool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CorveTool.DAL.Context;
using CorveTool.DAL.repositorys;
using CorveTool.DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        DatabaseContext db { get; set; }
        UsersRepository userrepository { get; set; }
        public HomeController()
        {
            db = new DatabaseContext();
            userrepository = new UsersRepository(db);
        }

        public async Task<IActionResult> Index()
        {
            var UserEmail = User.Identity.Name;
            if (db.Users.Any(x => x.Email == UserEmail))
            {
                Users user = await userrepository.Find(UserEmail);
                ViewData["firstname"] = user.FirstName;
                ViewData["lastname"] = user.LastName;
                ViewData["email"] = user.Email;
                ViewData["slackname"] = user.SlackName;
                return View();
            }
            else
            {
                var userinfo = new Users
                {
                    Email = UserEmail
                };

                return Redirect("Home/Register");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Info";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users model)
        {

            var firstname = Request.Form["firstname"];
            var lastname = Request.Form["lastname"];
            var email = User.Identity.Name;
            var slackname = Request.Form["slackname"];

            var userinfo = new Users
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                SlackName = slackname
            };

            await userrepository.Add(userinfo);

            return Redirect(nameof(Index));
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (db.Users.Any(x => x.Email == User.Identity.Name))
            {
                return Redirect(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
