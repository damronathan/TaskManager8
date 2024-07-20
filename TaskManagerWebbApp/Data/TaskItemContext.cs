using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagerWebbApp.Models;

public class TaskItemContext : DbContext
{
    public TaskItemContext(DbContextOptions<TaskItemContext> options) : base(options) { }

    public DbSet<TaskManagerWebbApp.Models.TaskItem> TaskItems { get; set; }
}

