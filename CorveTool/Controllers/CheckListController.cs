using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorveTool.DAL.repositorys;
using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using CorveTool.Models;
using System.Globalization;

namespace CorveTool.Controllers
{
    public class CheckListController : Controller
    {
        
        private int year = DateTime.Now.Year;

        DatabaseContext Db { get; set; }
        CheckListRepository Checklistrepository { get; set; }
        TasksRepository Taskrepository { get; set; }
        public CheckListController()
        { 
            Db = new DatabaseContext();
            Checklistrepository = new CheckListRepository(Db);
            Taskrepository = new TasksRepository(Db);
        }
        public IActionResult Index()
        {
            ViewData["query"] = Db.CheckList.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CheckList model)
        {
            var task = Request.Form["task"].ToString();
            int weeknumber = int.Parse(Request.Form["weeknumber"]);

            var info = new CheckList
            {
                  WeekNumber = weeknumber, Checked = false
            };
            await Checklistrepository.Add(info);

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

            var tasks = await Taskrepository.GetAll();
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