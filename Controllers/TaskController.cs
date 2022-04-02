using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Functions;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        
        private TaskFunctions taskFunctions;
        private SelectList CatgoriesList;

        public TaskController(CrudContext context)
        {
            taskFunctions = new TaskFunctions(context);
            CatgoriesList = taskFunctions.getCategories();
        }

        public IActionResult Index()
        {

            return View(taskFunctions.tasks());
        }

        public IActionResult Details(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }            
            var tks = taskFunctions.getDetails(id);
            if (tks == null)
            {
                return NotFound();      
            }

            return View(tks);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tks = taskFunctions.getDetails(id);
            ViewData["CategoryName"] = CatgoriesList;

            if (tks == null)
            {
                return NotFound();
            }
            return View(tks);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,Task task)
        {
            if (id == null)
            {
                return NotFound();
            }
            taskFunctions.editTask(id, task);

            TempData["Message"] = "Person Edited";
            return RedirectToAction("Index");

            
        }




    }
}
