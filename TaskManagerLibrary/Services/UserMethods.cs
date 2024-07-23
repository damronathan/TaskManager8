using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerLibrary.Models;

namespace TaskManagerLibrary.Services
{
    public class UserMethods
    {
        public UserMethods() { }
        
        public static User PromptForUser()
        {
            User user = new User();
            Console.Write("Enter Username: ");
            user.Username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string? password = Console.ReadLine();
            Console.WriteLine($"Welcome {user.Username}");
            return user;
        }
        public static User NewUser()
        {
            User user = new User();
            Console.Write("Choose Username: ");
            user.Username = Console.ReadLine();
            Console.Write("Choose password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine($"{user.Username} has been created");
            return user;
        }
    }
}
