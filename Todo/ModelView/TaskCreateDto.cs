using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.ModelView
{
    public class TaskCreateDto
    {
        [Required(ErrorMessage ="Enter Task")]
        public string Task { get; set; }
    }
}
