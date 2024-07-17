using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public TaskItem()
        {
            Title = string.Empty;
            Description = string.Empty;
        }
        public TaskItem(int id, string title, string description, bool isComplete)
        {
            ID = id;
            Title = title;
            Description = description;
            IsComplete = isComplete;
        }

       

    }
}
