namespace TaskBoardWebApp.Models
{
    public class Artifact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rare { get; set; }    
        public string Description { get; set; }
        public string Image { get; set; }
        public int Power { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
