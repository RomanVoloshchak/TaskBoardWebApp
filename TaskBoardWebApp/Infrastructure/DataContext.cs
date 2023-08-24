using Microsoft.EntityFrameworkCore;
using TaskBoardWebApp.Models;

namespace TaskBoardWebApp.Infrastructure
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {            
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }
    }
}
