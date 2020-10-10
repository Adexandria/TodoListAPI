using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Entity;

namespace Todo.Services
{
    public class TodoRespository : ITodo
    {
        private readonly TodoDb db;
        public IEnumerable<Tasks> GetTasks
        {
            get
            {
                return db.Tasks.OrderBy(r => r.Id);
            }
        }

        public async Task<Tasks> Add(Tasks task)
        {
            if(task== null)
            {
                throw new NullReferenceException(nameof(task));
            }
            task.Id = new Guid();
             await db.Tasks.AddAsync(task);
            return task;
        }

        public  async Task<int> Delete(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            var query = await GetTask(id);
            db.Tasks.Remove(query);
            return await db.SaveChangesAsync();
        }

        public async Task<Tasks> GetTask(Guid id)
        {
            if(id== null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.Tasks.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public  async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }

        public Tasks Update(Tasks task)
        {
            if (task == null)
            {
                throw new NullReferenceException(nameof(task));
            }
            var query = db.Tasks.Attach(task);
            query.State = EntityState.Modified;
            return task;
        }
    }
}
