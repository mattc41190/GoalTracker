using GoalTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoalTracker.Controllers
{
    public class TaskController : Controller
    {
        private TaskContext db = new TaskContext();
        
        // GET: All Task
        public ActionResult Index()
        {
            DbSet<Task> tasks = db.Tasks;
            

            return View(tasks);
        }
        
        // GET: Task Details
        public ActionResult Details(int id = 1)
        {
            TaskContext taskContext = new TaskContext();
            Task task = taskContext.Tasks.Single(tsk => tsk.ID == id);

            return View(task);
        }

        // GET: Create page
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,EntryDate,CompletionDate,Difficulty,InsertUser,Type,Tag")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Edit Page
        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            TaskContext taskContext = new TaskContext();
            Task task = taskContext.Tasks.Single(tsk => tsk.ID == id);

            return View(task);
        }

        // POST: Edit Page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,EntryDate,CompletionDate,Difficulty,InsertUser,Type,Tag")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }
    }
}