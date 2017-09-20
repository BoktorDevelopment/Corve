using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CorveTool.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private IRepository<Schedules> ScheduleRepository { get; set; }
        private IRepository<Tasks> TaskRepository { get; set; }
        private IRepository<Users> UserRepository { get; set; }

        public HomeController(IRepository<Schedules> scheduleRepository, IRepository<Tasks> taskRepository, IRepository<Users> userRepository)
        {
            ScheduleRepository = scheduleRepository;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var UserEmail = User.Identity.Name;
            if (UserRepository.Find(UserEmail) != null)
            {
                Users user = await UserRepository.Find(UserEmail);
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

            await UserRepository.Add(userinfo);

            return Redirect(nameof(Index));
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (UserRepository.Find(User.Identity.Name) != null)
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
