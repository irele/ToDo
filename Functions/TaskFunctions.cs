using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Models;
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
            //foreach (Task t in _context.Tasks.ToList())
            //{
                
            //}
            //tks = _context.Tasks.ToList();
            //tks.
            return _context.Tasks.ToList(); 
        }

        internal Task details(int? id)
        {
            return _context.Tasks.SingleOrDefault(x => x.ID == id);
        }
    }
}
