using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Entity;

namespace Todo.Services
{
    public interface ITodo
    {
        //Get tasks
        IEnumerable<Tasks> GetTasks{ get; }

        //Get an Individual by id
        Task<Tasks> GetTask(Guid id);

        //add task
        Task<Tasks> Add(Tasks task);

        //update task
        Tasks Update(Tasks task);

        //Delete task by id
        Task<int> Delete(Guid id);

        //saves task
        Task<int> SaveChanges();
    }
}
