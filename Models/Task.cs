using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{

    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status {get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }

        //foreign key for category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
