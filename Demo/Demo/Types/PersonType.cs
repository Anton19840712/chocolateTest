using Demo.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace Demo.Types
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .ResolveWith<Resolvers>(t => t.GetPersons(default!, default!))
                .UseDbContext<PersonContext>()
                .UseFiltering()
                .UseSorting();
        }
        protected class Resolvers
        {
            public IQueryable<Person>? GetPersons(Person person, [ScopedService] PersonContext dbContext) =>
                dbContext.Persons?.Where(t => t.Id == person.Id);
        }
    }
}