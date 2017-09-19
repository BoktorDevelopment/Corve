using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CorveTool.Models;
using System.Diagnostics;
using CorveTool.DAL.repositorys;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;

namespace CorveTool.Controllers
{

    public class TaskController : Controller
    {
        static DatabaseContext db = new DatabaseContext();
        TasksRepository taskrepository = new TasksRepository(db);


        public async Task<IActionResult> Index()
        {
            var tasks = await taskrepository.GetAll();
            ViewData["tasks"] = tasks.Select(x => new TasksViewModel { Id = x.Id, Task = x.Task }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Tasks model)
        {

            if (model.Task != "") {
                var task = new Tasks
                {
                    Task = model.Task
                };

                await taskrepository.Add(task);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Tasks model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
               

                Tasks record = await taskrepository.Find(model.Id);

                record.Id = model.Id;
                record.Task = model.Task;

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var res = await taskrepository.Find(id);
            TasksViewModel record = new TasksViewModel { Id = res.Id, Task = res.Task };
            return View(record);
        }
        public async Task<IActionResult> Remove(int id)
        {
            await taskrepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}





