using Microsoft.AspNetCore.Mvc;
using ToDoListModel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ToDoTask> Get()
        {
            return ToDoTask.ReadAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            var task = ToDoTask.Read(id);
            return task;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string description)
        {
            ToDoTask newTask = new ToDoTask(description);
            newTask.Create();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id to finnish}")]
        public void Put(int id)
        {
            ToDoTask task = ToDoTask.Read(id);
            task.FinishTask();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id to delete}")]
        public void Delete(int id)
        {
            ToDoTask task = ToDoTask.Read(id);
            task.Delete();
        }
    }
}
