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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoTask))]
        public ActionResult<IEnumerable<ToDoTask>> Get()
        {
            IEnumerable<ToDoTask> tasks = ToDoTask.ReadAll();
            return Ok(tasks);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var task = ToDoTask.Read(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/<ValuesController>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return BadRequest("The string can't be empty");
            }
            ToDoTask newTask = new ToDoTask(description);
            newTask.Create();
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }

        // PUT api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id to finnish}")]
        public IActionResult Put(int id)
        {
            ToDoTask task = ToDoTask.Read(id);
            if (task == null)
            {
                return NotFound();
            }
            task.FinishTask();
            return Ok(task);
        }

        // DELETE api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id to delete}")]
        public IActionResult Delete(int id)
        {
            ToDoTask task = ToDoTask.Read(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Delete();
            return NoContent();
        }
    }
}
