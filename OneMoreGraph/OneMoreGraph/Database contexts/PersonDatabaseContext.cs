using Microsoft.EntityFrameworkCore;
using OneMoreGraph.Models.PersonModels;

namespace OneMoreGraph.Database_contexts;

public class PersonDatabaseContext : DbContext
{
    public PersonDatabaseContext(DbContextOptions options) : base(options) { }
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>();
    }
}