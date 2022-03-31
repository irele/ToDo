using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Functions;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        
        private TaskFunctions taskFunctions; 

        public TaskController(CrudContext context)
        {
            taskFunctions = new TaskFunctions(context);
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

            var tks = taskFunctions.details(id);
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

            var tks = taskFunctions.details(id);
            if (tks == null)
            {
                return NotFound();
            }
            return View(tks);
        }

    }
}
