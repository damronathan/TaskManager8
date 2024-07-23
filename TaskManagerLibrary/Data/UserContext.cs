using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagerLibrary.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
}
