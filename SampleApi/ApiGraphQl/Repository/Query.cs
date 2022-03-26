using ApiGraphQl.Context;
using ApiGraphQl.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGraphQl.Repository

{
    public class Query
    {
        public string SayHello(string? name = "Antonio") => $"Here I am! My name is {name}";
        public string SayName(string? name = "Irina") => $"The name is {name}";

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public List<Person> GetPersons([ScopedService] PersonContext dbContext)
        {
            var persons = dbContext.Persons?.ToList();

            return persons ?? new List<Person>();
        }

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
