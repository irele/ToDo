using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
