using TaskManagerLibrary.Services;
using TaskManagerLibrary.Models;
using TaskManagerApp.Services;

User user = new User();
Console.WriteLine("Task Manager");
Console.WriteLine("");
Console.WriteLine("1. Log in to existing profile");
Console.WriteLine("2. Create new profile");
int selection = Convert.ToInt32(Console.ReadLine());
switch (selection)
{
    case 1:
        user = UserMethods.PromptForUser();
        break;
    case 2:
        user = UserMethods.NewUser();
        break;
}

Console.ReadLine();
