using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebToDoList.DataTasks;

namespace WebToDoList.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> TodayTasks()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        public async Task<IActionResult> TomorrowTasks()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,Date,priorities")] Tasks tasks)
        {
            if(tasks.Text == null)
            {
                return View(tasks);
            }
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasks);
        }

        
        public IActionResult IsCompleted(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var task = _context.Tasks.Find(Id);
            if (!task.IsCompleted)
                task.IsCompleted = true;
            else task.IsCompleted = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                var tasks = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
