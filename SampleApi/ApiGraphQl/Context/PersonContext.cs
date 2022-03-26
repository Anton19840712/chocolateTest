using ApiGraphQl.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGraphQl.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Person>? Persons { get; set; }
    }
}