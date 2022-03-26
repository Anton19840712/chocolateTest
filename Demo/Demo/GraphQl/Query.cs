using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.GraphQl
{
    public class Query
    {
        public string SayHello(string? name = "Antonio") => $"Here I am! My name is {name}";
        public string SayName(string? name = "Irina") => $"The name is {name}";
                
        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person>? GetPersons([ScopedService] PersonContext dbContext) => dbContext.Persons;
        
        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<Person> GetPersonByIdAsync(int id, [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.FirstOrDefaultAsync(t => t.Id == id)
                : new Person();
        }
    }
}