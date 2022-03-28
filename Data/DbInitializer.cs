using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using Task = ToDo.Models.Task;
namespace ToDo.Data
{
    public class DbInitializer
    {
        public static void Initialize (CrudContext context)
        {
            context.Database.EnsureCreated();
            
            if(context.Tasks.Any())
            {
                return;
            }

            var catgory = new Category[]
            {
                new Category{ CategoryName ="Work"},
                new Category{ CategoryName ="Family"}
            };

            DateTime date = new DateTime(2022, 3, 28);

            var task = new Task[]
            {
                new Task { Name ="call mom", CategoryId = 2, Details ="talk about by a new car", Status =false , DueDate = date},
                new Task { Name ="meet with james", CategoryId = 1, Details ="find a fix for the bug", Status =false , DueDate = date}
            };

            foreach(Category c in catgory)
            {
                context.Categories.Add(c);
            }

            foreach(Task t in task)
            {
                context.Tasks.Add(t);
            }

            context.SaveChanges();
        }
    }
}
