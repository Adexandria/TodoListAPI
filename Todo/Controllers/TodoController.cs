using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Entity;
using Todo.ModelView;
using Todo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/todolist")]
    public class TodoController : ControllerBase
    {
        private readonly ITodo db;
        private readonly IMapper mapper;
        public TodoController(ITodo db, IMapper mapper)
        {
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }
        //Get Tasks
        [HttpGet]
        public IActionResult Get()
        {
            var query = db.GetTasks;
            var newquery = mapper.Map<IEnumerable<TasksDto>>(query);
            return Ok(newquery);
        }

        //Get task by Id
        [HttpGet("{id}",Name ="Task")]
        public async Task<ActionResult<TasksDto>> GetById(Guid id)
        {
            var query = await db.GetTask(id);
            if (query == null)
            {
                return NotFound();
            }
            var newquery = mapper.Map<TaskDto>(query);
            return Ok(newquery);
        }
        //add new task
        [HttpPost]
        public async Task<ActionResult<TasksDto>> Post(TaskCreateDto task)
        {
            var query = mapper.Map<Tasks>(task);
            await db.Add(query);
            await db.SaveChanges();
            var newquery = mapper.Map<TasksDto>(query);
            return CreatedAtRoute("Task", new { id = newquery.Id }, newquery);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var query = await db.GetTask(id);
            if(query == null)
            {
                return NotFound();
            }
             await db.Delete(query.Id);
            return Ok();
        }
    }
}
