using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Functions
{
    public class CategoryFunctions
    {
        private readonly CrudContext _context;
        public CategoryFunctions(CrudContext crudContext)
        {
            _context = crudContext;
        }

        internal void create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();

        }

        internal List<Category> categories()
        {
            return _context.Categories.ToList();
        }
    }
}
