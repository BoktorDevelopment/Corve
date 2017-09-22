using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.Controllers
{

    public class TaskController : Controller
    {
        private IRepository<Schedules> ScheduleRepository { get; set; }
        private IRepository<Tasks> TaskRepository { get; set; }
        private IRepository<Users> UserRepository { get; set; }

        public TaskController(IRepository<Schedules> scheduleRepository, IRepository<Tasks> taskRepository, IRepository<Users> userRepository)
        {
            ScheduleRepository = scheduleRepository;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
           
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await TaskRepository.GetAll();
            ViewData["tasks"] = tasks.Select(x => new TasksViewModel { Id = x.Id, Task = x.Task }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tasks model)
        {

            if (model.Task != "")
            {
                var task = new Tasks
                {
                    Task = model.Task
                };

                TaskRepository.Add(task);
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
                Tasks record = await TaskRepository.Find(model.Id);

                record.Task = model.Task;
                TaskRepository.SaveChangesAsync();

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
            var res = await TaskRepository.Find(id);
            TasksViewModel record = new TasksViewModel { Id = res.Id, Task = res.Task };
            return View(record);
        }

        public async Task<IActionResult> Remove(int id)
        {
            TaskRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}





