namespace TaskBoardWebApp.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Task> Tasks { get; set;}
    }
}
