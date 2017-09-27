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
    public class ScheduleController : Controller
    {
        private int year = DateTime.Now.Year;
        private int weeknumber;
        private int weeknumbers;


        public int Weeknumber { get => weeknumber; set => weeknumber = value; }

        private SchedulesRepository SchedulesRepository { get; set; }
        private ScheduleTaskRepository ScheduleTaskRepository { get; set; }
        private TaskRepository TasksRepository { get; set; }
        private UsersRepository UsersRepository { get; set; }

        public ScheduleController(
            IRepository<Schedules> schedulesRepository,
            IRepository<Tasks> tasksRepository,
            IRepository<Users> usersRepository, 
            IRepository<ScheduleTask> scheduleTaskRepository)
        {
            SchedulesRepository = (SchedulesRepository)schedulesRepository;
            TasksRepository = (TaskRepository)tasksRepository;
            UsersRepository = (UsersRepository)usersRepository;
            ScheduleTaskRepository = (ScheduleTaskRepository)scheduleTaskRepository;

            //get week number of the year
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            int weeknumber = weekNumber;

            //get total weeknumbers in year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            weeknumbers = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        }

        public async Task<IActionResult> Index()
        {
            //weeknumbers in year
            ViewData["weeknumbers"] = weeknumbers;
            //get week number of year
            ViewData["weekNumber"] = Weeknumber;

            //get al the info from the database for the schedule

            var schedule = await ScheduleTaskRepository.GetAllAsync();
            ViewData["info"] = schedule.Select(x => new ScheduleTaskViewModel { Week = x.Week, User = x.User }).ToList();


            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tasks = await TasksRepository.GetAllAsync();
            var users = await UsersRepository.GetAllAsync();
            ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();
            ViewData["tasks"] = tasks.Select(x => new TasksViewModel { Id = x.Id, Task = x.Task }).ToList();
            //calculate how many weeks in a year

            ViewData["weeknumbers"] = weeknumbers;
            //get week number of year


            ViewData["error"] = "";


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ScheduleTask model)
        {
            if (ScheduleTaskRepository.Any(model.Week) == true)
            {
                ViewData["error"] = "Error - this weeknumber is already scheduled";

                ViewData["weeknumbers"] = weeknumbers;

                var users = await UsersRepository.GetAllAsync();
                ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName }).ToList();
                return View();
            }
            else
            {
                var info = new ScheduleTask
                {
                    Week = model.Week,
                    User = model.User
                };
                ScheduleTaskRepository.Add(info);
                return Redirect(nameof(Index));
            }
        }

        public async Task<IActionResult> Remove(int id)
        {

            return Redirect("../");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ScheduleTask model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                ScheduleTask record = await ScheduleTaskRepository.FindByWeekAsync(model.Week);
                record.User = model.User;
                await ScheduleTaskRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var users = await UsersRepository.GetAllAsync();
                ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int week)
        {

            ViewData["weeknumbers"] = weeknumbers;
            ViewData["week"] = week;

            var users = await UsersRepository.GetAllAsync();
            ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            return View();
        }
    }
}