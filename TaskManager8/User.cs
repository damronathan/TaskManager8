using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Models;

public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; }
    public User()
    {
        Username = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
    public User(int id, string username, string email, string password, List<Task> tasks)
    {
        ID = id;
        Username = username;
        Email = email;
        Password = password;
        Tasks = tasks;
    }
    public override string ToString()
    {
        {
            return $"{ID}/{Username}/{Email}/{Password}/{Tasks.ToString}";
        }
    }
    public static User FromString(string userString)
    {
        var parts = userString.Split('/');
        return new User
        {
            ID = int.Parse(parts[0]),
            Username = parts[1],
            Email = parts[2],
            Password = parts[3],
        };
    }
}
