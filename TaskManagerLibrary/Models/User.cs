namespace TaskManagerLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
        public User(int id, string username, string password)
        {
            UserId = id;
            Username = username;
            Password = password;
        }
    }

}
