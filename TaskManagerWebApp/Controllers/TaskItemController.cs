using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerLibrary.Models;

[Route("api/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    private readonly TaskItemContext _context;

    public TaskItemController(TaskItemContext context)
    {
        _context = context;
    }

    // GET: api/TaskItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.TaskItem.ToListAsync();
    }

    // GET: api/TaskItem/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var task = await _context.TaskItem.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    // POST: api/TaskItem
    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostTask(TaskItem task)
    {
        _context.TaskItem.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/TaskItem/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, TaskItem task)
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

    // DELETE: api/TaskItem/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.TaskItem.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.TaskItem.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TaskExists(int id)
    {
        return _context.TaskItem.Any(e => e.Id == id);
    }
}

