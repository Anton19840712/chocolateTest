using GraphQlBasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlBasicApi.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}