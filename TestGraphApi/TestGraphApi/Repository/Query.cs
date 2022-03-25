using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using TestGraphApi.Context;
using TestGraphApi.Models;

namespace TestGraphApi.Repository

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
            if (dbContext.Persons!=null)
            {
                return dbContext.Persons.ToList();
            }
            else
            {
                return new List<Person>();
            }
            
        }

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public Task<Person> GetPersonByIdAsync(int id, [ScopedService] PersonContext dbContext) =>
            dbContext.Persons.FirstOrDefaultAsync(t => t.Id == id);
    }
}
