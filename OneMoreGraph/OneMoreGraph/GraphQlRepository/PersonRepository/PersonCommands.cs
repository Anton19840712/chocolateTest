using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using OneMoreGraph.Database_contexts;
using OneMoreGraph.Models.PersonModels;

namespace OneMoreGraph.GraphQlRepository.PersonRepository;

public class PersonCommands
{
    [UseDbContext(typeof(PersonDatabaseContext))]
    public async Task<PersonResponse> AddAuthorAsync(PersonRequest input, [ScopedService] PersonDatabaseContext dbContext)
    {
        var person = new Person
        {
            FirstName = input.Name,

            Score = input.Score
        };

        dbContext.Persons.Add(person);

        await dbContext.SaveChangesAsync();

        return new PersonResponse(person);
    }
}