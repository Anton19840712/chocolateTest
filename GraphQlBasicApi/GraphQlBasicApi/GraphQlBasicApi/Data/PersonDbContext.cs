using GraphQlBasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlBasicApi.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}