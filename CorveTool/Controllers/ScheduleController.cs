using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorveTool.DAL.repositorys;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CorveTool.Models;
using System.Globalization;

namespace CorveTool.Controllers
{
    public class ScheduleController : Controller
    {
        private int year = 2017;

        DatabaseContext db { get; set; }
        ScheduleTaskRepository Scheduletaskrepository { get; set; }
        ScheduleRepository Schedulesrepository { get; set; }
        TasksRepository tasksrepository { get; set; }
        UsersRepository usersrepository { get; set; }

        public ScheduleController()
        {
            db = new DatabaseContext();
            Scheduletaskrepository = new ScheduleTaskRepository(db);
            Schedulesrepository = new ScheduleRepository(db);
            tasksrepository = new TasksRepository(db);
            usersrepository = new UsersRepository(db);
        }

        public async Task<IActionResult> Index()
        {
            //calculate how many weeks in a year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            ViewData["weeknumbers"] = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
            //get week number of year
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            ViewData["weekNumber"] = weekNumber;

            //get al the info from the database for the schedule

            var schedule = await Scheduletaskrepository.GetAll();
            ViewData["info"] = schedule.Select(x => new ScheduleTaskViewModel { Week = x.Week, User = x.User}).ToList();


            return View();
            
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tasks = await tasksrepository.GetAll();
            var users = await usersrepository.GetAll();
            ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName}).ToList();
            ViewData["tasks"] = tasks.Select(x => new TasksViewModel { Id = x.Id, Task = x.Task }).ToList();
            //calculate how many weeks in a year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            ViewData["weeknumbers"] = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
            //get week number of year
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            ViewData["weekNumber"] = weekNumber;

            ViewData["error"] = "";


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ScheduleTask model)
        {
            int weeknumber = int.Parse(Request.Form["weeknumber"]);
            var user = Request.Form["user"];

            if (db.ScheduleTask.Any(x => x.Week == weeknumber))
            {
                ViewData["error"] = "Error - this weeknumber is already scheduled";
                //calculate how many weeks in a year
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date1 = new DateTime(year, 12, 31);
                Calendar cal = dfi.Calendar;
                ViewData["weeknumbers"] = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                    dfi.FirstDayOfWeek);

                var users = await usersrepository.GetAll();
                ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName }).ToList();
                return View();
            }
            else
            {
                var info = new ScheduleTask
                {
                    Week = weeknumber,
                    User = user
                };
                await Scheduletaskrepository.Add(info);
                return RedirectToAction("../schedule/add");
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
                var user = Request.Form["user"];

                ScheduleTask record = await Scheduletaskrepository.Find(model.Week);

                record.User = model.User;

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int week)
        {
            //calculate how many weeks in a year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            ViewData["weeknumbers"] = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);

            var users = await usersrepository.GetAll();
            ViewData["users"] = users.Select(x => new UsersViewModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            var res = await Scheduletaskrepository.Find(week);
            ScheduleTaskViewModel record = new ScheduleTaskViewModel { Id = res.Id, User = res.User, Week = res.Week };

            return View(record);
        }
        public IActionResult WeekSchedule()
        {
            //calculate how many weeks in a year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            ViewData["weeknumbers"] =  cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);      
            //get week number of year
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            ViewData["weekNumber"] = weekNumber;


            return View();
        }
    }
}