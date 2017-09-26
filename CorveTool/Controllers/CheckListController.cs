using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.Controllers
{
    public class CheckListController : Controller
    {
        int weeknumber = 0;
        private int year = DateTime.Now.Year;

        private IRepository<Tasks> TaskRepository { get; set; }
        private IRepository<CheckList> ChecklistRepository { get; set; }

        public CheckListController(IRepository<Schedules> scheduleRepository, IRepository<Tasks> taskRepository, IRepository<Users> userRepository, IRepository<CheckList> checklistRepository)
        {
            TaskRepository = taskRepository;
            ChecklistRepository = checklistRepository;

            //get weeknumber
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            weeknumber = weekNumber;
            ViewData["test"] = "";

        }

        [HttpPost]
        public async Task<IActionResult> Index(int[] Checked)
        {
            foreach (var item in Checked)
            {
                CheckList result = await ChecklistRepository.Find(item);
                result.Checked = true;
                ChecklistRepository.SaveChangesAsync();
            }
            return Redirect("../CheckList");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var checklist = (await ChecklistRepository.GetAll()).Select(x => new CheckListViewModel { Id = x.Id, Task = x.Task, WeekNumber = x.WeekNumber, Checked = x.Checked }).ToList();
            ViewData["weeknumber"] = weeknumber;

            return View(checklist);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CheckListViewModel model)
        {
            var task = await TaskRepository.Find(model.TaskId);

            var info = new CheckList
            {
                TaskId = task.Id,
                WeekNumber = model.WeekNumber,
                Checked = false
            };
            ChecklistRepository.Add(info);

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