using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebToDoList.DataTasks;

namespace WebToDoList.Controllers
{
    public class HomeController : Controller
    {
        TaskContext db;
        public HomeController(TaskContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Tasks.ToList());
        }
    }
}
