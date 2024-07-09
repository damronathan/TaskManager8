using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public Task()
        {
            Title = string.Empty;
            Description = string.Empty;
        }
        public Task(int id, string title, string description, bool isComplete)
        {
            ID = id;
            Title = title;
            Description = description;
            IsComplete = isComplete;
        }

        public override string ToString()
        {
            return $"{ID}/{Title}/{Description}/{IsComplete}";
        }
        public static Task FromString(string taskString)
        {
            var parts = taskString.Split('/');
            return new Task
            {
                ID = int.Parse(parts[0]),
                Title = parts[1],
                Description = parts[2],
                IsComplete = bool.Parse(parts[3])
            };
        }

    }
}
