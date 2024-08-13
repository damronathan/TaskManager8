using System;
using System.Collections.Generic;
using TaskManagerApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaskManagerLibrary.Services;
using TaskManagerLibrary.Models;
using System.Diagnostics;

TaskService taskService = new TaskService();
TaskMethods taskMethods = new TaskMethods(taskService);
var tasks = await taskService.GetTasksAsync();
var userService = new UserService();
var userMethods = new UserMethods(userService);
var users = await userService.GetUsersAsync();

User user = new User();
Console.WriteLine("Task Manager");
Console.WriteLine("");
Console.WriteLine("1. Log in to existing profile");
Console.WriteLine("2. Create new profile");
int selection = Convert.ToInt32(Console.ReadLine());

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

switch (selection)
{
    case 1:
        user = await userMethods.LoadUserAsync();
        Console.WriteLine($"Welcome back {user.Username}");
        break;
    case 2:
        user = await userMethods.AddUserAsync();
        Console.WriteLine($"Welcome {user.Username}");
        break;
}

List<TaskItem> userTasks = new List<TaskItem>();
foreach (var task in tasks)
{
    if (task.UserId == user.UserId)
    {
        userTasks.Add(task);
    }
}


while (true)
{


    selection = taskMethods.DisplayMenuAndGetSelection(menu);

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

