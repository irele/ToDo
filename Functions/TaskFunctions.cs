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
            var categories = _context.Categories.ToList();

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].CategoryName == task.CategoryName)
                {
                    task.CategoryId = categories[i].Id;
                    break;
                }
            }
            _context.Update(task);
            _context.SaveChanges();

        }

        internal void createTask(Task task)
        {
            var categories = _context.Categories.ToList();
           for(int i = 0; i < categories.Count; i++)
            {
                if(categories[i].CategoryName == task.CategoryName)
                {
                    task.CategoryId = categories[i].Id;
                    break;
                }
            }
            _context.Add(task);
            _context.SaveChanges();

        }

        internal bool delete(int? id)
        {
            Task  tasks = _context.Tasks.SingleOrDefault(x => x.ID == id);

            if (tasks == null)
            {
                return false;
            }
            _context.Remove(tasks);
            _context.SaveChanges();

            return true;
        }
    }
}
