using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerLibrary.Models;
using TaskManagerLibrary.Services;

namespace TaskManagerApp.Services
{
    public class MenuMethods
    {
        private readonly TaskService _taskService;

        public MenuMethods(TaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskItem> PromptForTaskAsync()
        {
            Console.WriteLine();
            Console.Write("Enter task title: ");
            string? title = Console.ReadLine();
            title = title ?? string.Empty;

            Console.Write("Enter task description: ");
            string? description = Console.ReadLine();
            description = description ?? string.Empty;

            bool isComplete = false;
            int id = 0;
            return new TaskItem(id, title, description, isComplete);
        }

        public int DisplayMenuAndGetSelection(List<string> menu)
        {
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
            string? selectedNumber = Console.ReadLine();
            while (selectedNumber != "1" && selectedNumber != "2" && selectedNumber != "3" && selectedNumber != "4"
                    && selectedNumber != "5" && selectedNumber != "6")
            {
                Console.WriteLine();
                Console.WriteLine("INCORRECT INPUT");
                foreach (string item in menu)
                {
                    Console.WriteLine(item);
                }
                selectedNumber = Console.ReadLine();
            }
            return Convert.ToInt32(selectedNumber);
        }

        public async Task AddTaskAsync()
        {
            while (true)
            {
                TaskItem newTask = await PromptForTaskAsync();
                await _taskService.CreateTaskAsync(newTask);
                Console.Write("Do you want to add another task? (yes/no): ");
                string? continueInput = Console.ReadLine();
                if (continueInput?.ToLower() != "yes")
                {
                    break;
                }
            }
        }

        public async Task ViewTasksAsync()
        {
            var tasks = await _taskService.GetTasksAsync();
            if (tasks.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Tasks:");
                foreach (TaskItem task in tasks)
                {
                    string completionStatus = task.IsComplete ? "yes" : "no";
                    if (task.IsComplete)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine("Enter any key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no tasks.");
            }
        }

        public async Task MarkCompleteAsync()
        {
            var tasks = await _taskService.GetTasksAsync();
            if (tasks.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Tasks:");
                foreach (TaskItem task in tasks)
                {
                    string completionStatus = task.IsComplete ? "yes" : "no";
                    if (task.IsComplete)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.Write("Enter the number of the task you would like to mark completed: ");
                string? stringID = Console.ReadLine();
                if (!int.TryParse(stringID, out int selectedID))
                {
                    Console.WriteLine();
                    Console.WriteLine("INCORRECT INPUT");
                    await MarkCompleteAsync();
                    return;
                }
                TaskItem? selectedTask = tasks.FirstOrDefault(t => t.Id == selectedID);
                if (selectedTask != null)
                {
                    selectedTask.IsComplete = true;
                    await _taskService.UpdateTaskAsync(selectedTask);
                    Console.WriteLine();
                    Console.WriteLine($"{selectedTask.Title} is now marked as completed.");
                    Console.WriteLine();
                    Console.Write("Would you like to mark another task completed? (yes/no): ");
                    string? answer = Console.ReadLine();
                    if (answer?.ToLower() == "yes")
                    {
                        await MarkCompleteAsync();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no tasks.");
            }
        }

        public async Task UpdateTaskAsync()
        {
            var tasks = await _taskService.GetTasksAsync();
            if (tasks.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Tasks:");
                foreach (TaskItem task in tasks)
                {
                    string completionStatus = task.IsComplete ? "yes" : "no";
                    if (task.IsComplete)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.Write("Enter the number of the task you would like to update: ");
                string? stringID = Console.ReadLine();
                if (!int.TryParse(stringID, out int selectedID))
                {
                    Console.WriteLine();
                    Console.WriteLine("INCORRECT INPUT");
                    await UpdateTaskAsync();
                    return;
                }
                TaskItem? selectedTask = tasks.FirstOrDefault(t => t.Id == selectedID);
                if (selectedTask != null)
                {
                    Console.Write("Would you like to update the title? (yes/no): ");
                    string? answer = Console.ReadLine();
                    if (answer?.ToLower() == "yes")
                    {
                        Console.Write("Enter new title: ");
                        selectedTask.Title = Console.ReadLine() ?? string.Empty;
                    }
                    Console.Write("Would you like to update the description? (yes/no): ");
                    answer = Console.ReadLine();
                    if (answer?.ToLower() == "yes")
                    {
                        Console.Write("Enter new description: ");
                        selectedTask.Description = Console.ReadLine() ?? string.Empty;
                    }
                    Console.Write("Has this task been completed? (yes/no): ");
                    answer = Console.ReadLine();
                    selectedTask.IsComplete = answer?.ToLower() == "yes";

                    await _taskService.UpdateTaskAsync(selectedTask);
                    Console.WriteLine();
                    Console.WriteLine($"{selectedTask.Title} has been updated.");
                    Console.WriteLine();
                    Console.Write("Would you like to update another task? (yes/no): ");
                    answer = Console.ReadLine();
                    if (answer?.ToLower() == "yes")
                    {
                        await UpdateTaskAsync();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no tasks.");
            }
        }

        public async Task DeleteTaskAsync()
        {
            var tasks = await _taskService.GetTasksAsync();
            if (tasks.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Tasks:");
                foreach (TaskItem task in tasks)
                {
                    string completionStatus = task.IsComplete ? "yes" : "no";
                    if (task.IsComplete)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{task.Id}. Title: {task.Title} / Description: {task.Description} / Completed: {completionStatus}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.Write("Enter the number of the task you would like to delete: ");
                string? stringID = Console.ReadLine();
                if (!int.TryParse(stringID, out int selectedID))
                {
                    Console.WriteLine();
                    Console.WriteLine("INCORRECT INPUT");
                    await DeleteTaskAsync();
                    return;
                }
                TaskItem? selectedTask = tasks.FirstOrDefault(t => t.Id == selectedID);
                if (selectedTask != null)
                {
                    await _taskService.DeleteTaskAsync(selectedID);
                    Console.WriteLine();
                    Console.WriteLine($"{selectedTask.Title} has been deleted.");

                    Console.WriteLine();
                    Console.Write("Would you like to delete another task? (yes/no): ");
                    string? answer = Console.ReadLine();
                    if (answer?.ToLower() == "yes")
                    {
                        await DeleteTaskAsync();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no tasks.");
            }
        }
    }
}
