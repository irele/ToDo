using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Functions
{
    public class TaskFunctions
    {
        private readonly CrudContext _context;


        public TaskFunctions(CrudContext crudContext)
        {
            _context = crudContext;
        }

        public List<Task> tasks()
        {
            return _context.Tasks.ToList(); 
        }

        public Task getDetails(int? id)
        {
            return _context.Tasks.SingleOrDefault(x => x.ID == id);
        }

        public SelectList getCategories()
        {
            return new SelectList(_context.Categories.ToList(), "CategoryName", "CategoryName");
        }

        internal void editTask(int? id, Task task)
        {
            _context.Update(task);
            _context.SaveChanges();

        }
    }
}
