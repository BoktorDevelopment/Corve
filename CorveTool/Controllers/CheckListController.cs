using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorveTool.DAL.repositorys;
using CorveTool.DAL.Context;

namespace CorveTool.Controllers
{
    public class CheckListController : Controller
    {
        DatabaseContext db { get; set; }
        CheckListRepository checklistrepository { get; set; }
        public CheckListController()
        { 
            db = new DatabaseContext();
            checklistrepository = new CheckListRepository(db);
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Add()
        {
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