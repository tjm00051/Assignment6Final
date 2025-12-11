using Microsoft.EntityFrameworkCore;

namespace Assignment6Final
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=people.db");
        }
    }
}
