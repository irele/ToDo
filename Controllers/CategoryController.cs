using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Functions;

namespace ToDo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryFunctions categoryFunctions;

        public CategoryController(CrudContext context)
        {
            categoryFunctions = new CategoryFunctions(context);
        }
        
        public IActionResult Index()
        {
            return View(categoryFunctions.categories());
        }


        public IActionResult Create()
        {
            return View();
        }

    }
}
