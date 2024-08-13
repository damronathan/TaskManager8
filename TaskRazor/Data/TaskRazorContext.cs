using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagerLibrary.Models;

namespace TaskRazor.Data
{
    public class TaskRazorContext : DbContext
    {
        public TaskRazorContext(DbContextOptions<TaskRazorContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}

