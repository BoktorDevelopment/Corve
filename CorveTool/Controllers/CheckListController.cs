using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.Controllers
{
    public class CheckListController : Controller
    {

        private int year = DateTime.Now.Year;

        private IRepository<Tasks> TaskRepository { get; set; }
        private IRepository<CheckList> ChecklistRepository { get; set; }

        public CheckListController(IRepository<Schedules> scheduleRepository, IRepository<Tasks> taskRepository, IRepository<Users> userRepository, IRepository<CheckList> checklistRepository)
        {
            TaskRepository = taskRepository;
            ChecklistRepository = checklistRepository;
        }

        public IActionResult Index()
        {
            ViewData["query"] = ChecklistRepository.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CheckList model)
        {
            var task = Request.Form["task"].ToString();
            int weeknumber = int.Parse(Request.Form["weeknumber"]);

            var info = new CheckList
            {
                WeekNumber = weeknumber,
                Checked = false
            };
            await ChecklistRepository.Add(info);

            return Redirect(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //calculate how many weeks in a year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            ViewData["weeknumbers"] = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);

            var tasks = await TaskRepository.GetAll();
            ViewData["tasks"] = tasks.Select(x => new TasksViewModel { Id = x.Id, Task = x.Task }).ToList();

            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}