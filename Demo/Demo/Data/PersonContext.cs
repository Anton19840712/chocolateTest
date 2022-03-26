using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options) { }
        public DbSet<Person>? Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}