namespace TaskBoardWebApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExecuteDate { get; set; }
        public bool IsExecute { get; set; }
        public int Experience { get; set; }
        public int Rating { get; set; }

        public virtual Character Character { get; set; }
        public virtual TaskCategory Category { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
