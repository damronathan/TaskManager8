using System;
using System.Collections.Generic;
using TaskManagerApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaskManagerLibrary.Services;
using TaskManagerLibrary.Models;
using System.Diagnostics;
namespace TaskManagerApp

{
    class Program

    {

        static async Task Main(string[] args)
        {
            var taskService = new TaskService();
            var taskMethods = new TaskMethods(taskService);

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
                    int selection = taskMethods.DisplayMenuAndGetSelection(menu);
                    switch (selection)
                    {
                        case 1:
                            await taskMethods.AddTaskAsync();
                            break;
                        case 2:
                            await taskMethods.ViewTasksAsync();
                            break;
                        case 3:
                            await taskMethods.MarkCompleteAsync();
                            break;
                        case 4:
                            await taskMethods.UpdateTaskAsync();
                            break;
                        case 5:
                            await taskMethods.DeleteTaskAsync();
                            break;
                        case 6:
                            Process[] myProcList = Process.GetProcessesByName("TaskManagerWebApp");
                            foreach (Process Target in myProcList)
                            {
                                Target.Kill();
                            }
                            return;
                    }
                }
            }
        }
    }
}