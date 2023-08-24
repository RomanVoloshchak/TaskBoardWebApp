using System.ComponentModel.DataAnnotations.Schema;
namespace TaskBoardWebApp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }
        public virtual User User { get; set; }
    }
}
