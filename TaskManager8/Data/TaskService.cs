using System;
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


