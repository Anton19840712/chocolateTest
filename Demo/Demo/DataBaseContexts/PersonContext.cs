using Demo.Models.PersonModels.DalPersonsDto;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataBaseContexts
{
    /// <summary>
    /// Database context for EF Core.
    /// </summary>
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options) { }
        public DbSet<PersonDalDto> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}