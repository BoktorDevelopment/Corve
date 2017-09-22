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
            if (UserRepository.Any(UserEmail) == true)
            {
                Users user = await UserRepository.FindAsync(UserEmail);
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

                return Redirect("/Account/Register");
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

    }
}
