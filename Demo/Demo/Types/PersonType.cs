using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using Demo.DataBaseContexts;
using Demo.Models.PersonModels.DalPersonsDto;

namespace Demo.Types
{
    public class PersonType : ObjectType<PersonDalDto>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonDalDto> descriptor)
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
            public IQueryable<PersonDalDto>? GetPersons(PersonDalDto personDalDto, [ScopedService] PersonContext dbContext) =>
                dbContext.Persons?.Where(t => t.Id == personDalDto.Id);
        }
    }
}