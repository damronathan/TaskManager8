using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerWebbApp.Models;

[Route("api/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    private readonly TaskItemContext _context;

    public TaskItemController(TaskItemContext context)
    {
        _context = context;
    }

    // GET: api/Task
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskManagerWebbApp.Models.TaskItem>>> GetTask()
    {
        return await _context.TaskItems.ToListAsync();
    }

    // GET: api/Task/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    // POST: api/Task
    [HttpPost]
    public async Task<ActionResult<TaskManagerWebbApp.Models.TaskItem>> GetTask(TaskManagerWebbApp.Models.TaskItem task)
    {
        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/Task/5
    [HttpPut("{id}")]
    public async Task<IActionResult> GetTask(int id, TaskManagerWebbApp.Models.TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Task/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TaskExists(int id)
    {
        return _context.TaskItems.Any(e => e.Id == id);
    }
}

