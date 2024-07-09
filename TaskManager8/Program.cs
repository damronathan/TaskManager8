using System;
using System.Collections.Generic;
using TaskManagerApp.Services;
namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
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
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                int selection = MenuMethods.DisplayMenuAndGetSelection(menu);
                switch (selection)
                {
                    case 1:
                        MenuMethods.AddTask();
                        break;
                    case 2:
                        MenuMethods.ViewTasks();
                        break;
                    case 3:
                        MenuMethods.MarkComplete();
                        break;
                    case 4:
                        MenuMethods.Update();
                        break;
                    case 5:
                        MenuMethods.DeleteTask();
                        break;
                    case 6:
                        return;
                }
            }
        }
    }
}