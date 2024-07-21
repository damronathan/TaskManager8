using System;
using System.Collections.Generic;
using TaskManagerApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
namespace TaskManagerApp

{
    class Program

    {

        static async Task Main(string[] args)
        {
            var taskService = new TaskService();
            var menuMethods = new MenuMethods(taskService);

            // Get all tasks
            var tasks = await taskService.GetTasksAsync();
            {
                Console.WriteLine("TASK MANAGER");
                List<string> menu = new List<string>
            {
                "",
                "1. Add Task",
                "2. View Tasks",
                "3. Mark Task as Completed",
                "4. Update Task",
                "5. Delete Task",
                "6. Exit"
            };

                while (true)
                {
                    int selection = menuMethods.DisplayMenuAndGetSelection(menu);
                    switch (selection)
                    {
                        case 1:
                            await menuMethods.AddTaskAsync();
                            break;
                        case 2:
                            await menuMethods.ViewTasksAsync();
                            break;
                        case 3:
                            await menuMethods.MarkCompleteAsync();
                            break;
                        case 4:
                            await menuMethods.UpdateTaskAsync();
                            break;
                        case 5:
                            await menuMethods.DeleteTaskAsync();
                            break;
                        case 6:
                            return;
                    }
                }
            }
        }
    }
}