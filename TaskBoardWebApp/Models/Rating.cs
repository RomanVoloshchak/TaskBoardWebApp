namespace TaskBoardWebApp.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public DateTime RatingDate { get; set; }
        public virtual Task Task { get; set; }
    }
}
