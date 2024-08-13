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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTask()
    {
        return await _context.TaskItem.ToListAsync();
    }

HEAD:TaskManagerWebbApp/Controllers/TaskItemController.cs
  


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

3b34327ba75cab196fdd64246e3d36bf9a3a6560:TaskManagerWebApp/Controllers/TaskItemController.cs
    [HttpPost]
    public async Task<ActionResult<TaskItem>> GetTask(TaskItem task)
    {
        _context.TaskItem.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> GetTask(int id, TaskItem task)
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

