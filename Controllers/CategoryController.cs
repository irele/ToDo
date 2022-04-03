using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Functions;
using ToDo.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category )
        {
            categoryFunctions.create(category);

            TempData["Message"] = "Category Created";
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           //var delCat = CategoryFunctions.delete(id);

           // if (delCat == false)
           // {
           //     return NotFound();
           // }

            TempData["message"] = "Category deleted";
            return RedirectToAction("Index");
        }


    }
}
