namespace TaskManagerLibrary.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
/*        public int UserId { get; set; }
*/        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public TaskItem()
        {
            Title = string.Empty;
            Description = string.Empty;
        }
        public TaskItem(int id /*int userId*/, string title, string description, bool isComplete)
        {
            Id = id;
/*            UserId = userId;
*/            Title = title;
            Description = description;
            IsComplete = isComplete;
        }
    }
   
}
