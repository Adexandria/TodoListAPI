using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Entity;

namespace Todo.Services
{
    public class TodoDb :DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
