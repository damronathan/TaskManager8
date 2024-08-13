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
        private readonly UserService _userService;

        public UserMethods(UserService userService)
        {
            _userService = userService;
        }


        public async Task<User> AddUserAsync()
        {
            while(true)
            {
                User newUser = await PromptForUserAsync();
                await _userService.CreateUserAsync(newUser);
                return newUser;
            }

        }
        public async Task<User> PromptForUserAsync()
        {
            int id = 0;
            Console.Write("Choose Username: ");
            string? username = Console.ReadLine();
            Console.Write("Choose Password: ");
            string? password = Console.ReadLine();
            Console.WriteLine($"{username} has been created");
            return new User(id, username, password);
        }
        public async Task<User> LoadUserAsync()
        {
            var users = await _userService.GetUsersAsync();

            User selectedUser = new User();
            int id = 0;
            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = Console.ReadLine();
            foreach (User user in users)
            {
                if(username == user.Username && password == user.Password)
                {
                    selectedUser = user; break;
                }
            }
            return selectedUser;
        }
    }
}
