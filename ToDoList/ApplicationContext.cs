using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MyTask> tasks => Set<MyTask>();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasksDB.db");
        }
    }
}
