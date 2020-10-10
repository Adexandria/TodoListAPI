using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Entity
{
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }
        public string Task { get; set; }
    }
}
