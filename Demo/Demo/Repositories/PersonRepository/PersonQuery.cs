using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.DataBaseContexts;
using Demo.Models.PersonModels.DalPersonsDto;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.PersonRepository
{
    public class PersonQuery
    {
        public string SayHello(string? name = "Antonio") => $"Here I am! My name is {name}";
        public string SayName(string? name = "Irina") => $"The name is {name}";
                
        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonDalDto>? GetPersons([ScopedService] PersonContext dbContext) => dbContext.Persons;
        
        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<PersonDalDto> GetPersonByIdAsync(int id, [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.FirstOrDefaultAsync(t => t.Id == id)
                : new PersonDalDto();
        }

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<PersonDalDto>> GetPersonsIdsAsync(List<int> ids, [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.Where(s => ids.Contains(s.Id)).ToListAsync()
                : new List<PersonDalDto>();
        }

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<PersonDalDto>> GetPersonsScoreGreaterAsync(int number, [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.Where(s => s.Score> number).ToListAsync()
                : new List<PersonDalDto>();
        }

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<PersonDalDto>> GetPersonsScoreLessAsync(int number, [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.Where(s => s.Score < number).ToListAsync()
                : new List<PersonDalDto>();
        }

        [UseDbContext(typeof(PersonContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<PersonDalDto>> GetPersonsNameStartsAsync(string nameStartElement,  [ScopedService] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? await dbContext.Persons.Where(x => x.FirstName != null && x.FirstName.StartsWith(nameStartElement)).ToListAsync()
                : new List<PersonDalDto>();
        }
    }
}