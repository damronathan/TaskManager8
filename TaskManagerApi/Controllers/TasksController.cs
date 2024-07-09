using Microsoft.AspNetCore.Mvc;


namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/Tasks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
