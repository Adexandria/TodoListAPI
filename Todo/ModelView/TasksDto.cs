using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.ModelView
{
    public class TasksDto
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
    }
}
