/*using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class TaskService
    {
        private readonly TaskManagerDbContext _context;

        public TaskService(TaskManagerDbContext context)
        {
            _context = context;
        }

        public List<TaskManagerApp.Models.TaskItem> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public TaskManagerApp.Models.TaskItem GetTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                // Handle null case, throw exception, return default value, etc.
                throw new Exception($"TaskItem with ID {id} not found.");
            }
            return task;
        }

        public void CreateTask(TaskManagerApp.Models.TaskItem task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(int id, TaskManagerApp.Models.TaskItem updatedTask)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.IsComplete = updatedTask.IsComplete;
                _context.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
        public void ReorderTaskIds()
        {
            var tasks = _context.Tasks.OrderBy(t => t.ID).ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].ID = i + 1;
            }
            _context.SaveChanges();
        }
    }
}
*/
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskManagerApp.Models;
using System.Collections.Generic;
public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5111/") };
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<TaskItem>>("api/TaskItem");
    }

    public async Task<TaskItem> GetTaskByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<TaskItem>($"api/TaskItem/{id}");
    }

    public async Task CreateTaskAsync(TaskItem task)
    {
        var response = await _httpClient.PostAsJsonAsync("api/TaskItem", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/TaskItem/{task.Id}", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/TaskItem/{id}");
        response.EnsureSuccessStatusCode();
    }
}


