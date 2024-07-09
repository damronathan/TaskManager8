using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerApp.Models;
public class TaskManager
{
    private string filePath = "task.txt";
    private List<TaskManagerApp.Models.Task> tasks;
    public TaskManager()
    {
        tasks = new List<TaskManagerApp.Models.Task>();
        LoadTasks();
    }
    private void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            tasks = lines.Select(TaskManagerApp.Models.Task.FromString).ToList();
        }
    }
    private void SaveTasks()
    {
        var lines = tasks.Select(t => t.ToString()).ToArray();
        File.WriteAllLines(filePath, lines);
    }
    public void AddTask(TaskManagerApp.Models.Task task)
    {
        task.ID = tasks.Count > 0 ? tasks.Max(t => t.ID) + 1 : 1;
        tasks.Add(task);
        SaveTasks();
    }
    public List<TaskManagerApp.Models.Task> GetTasks()
    {
        return tasks;
    }
    public void UpdateTask(TaskManagerApp.Models.Task task)
    {
        var existingTask = tasks.FirstOrDefault(t => t.ID == task.ID);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsComplete = task.IsComplete;
            SaveTasks();
        }
    }
    public void DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.ID == id);
        if (task != null)
        {
            tasks.Remove(task);
            ReorderTaskIDs();
            SaveTasks();
        }
    }
    private void ReorderTaskIDs()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            tasks[i].ID = i + 1;
        }
    }
}
