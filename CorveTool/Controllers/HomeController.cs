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

        public HomeController(IRepository<Schedules> scheduleRepository, IRepository<Tasks> taskRepository)
        {
            ScheduleRepository = scheduleRepository;
            TaskRepository = taskRepository;
        }

        public async Task<IActionResult> Index()
        {
            var all = await TaskRepository.GetAll();
            return View(all);
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
