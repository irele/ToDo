using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ToDo.Models.Task;

namespace ToDo.Data
{
    public class CrudContext: DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
                
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
