using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.GraphQl
{
    public record AddAuthorInput(string Name);

    [ExtendObjectType("Mutation")]
    public class Mutation
    {
        [UseDbContext(typeof(PersonContext))]
        public async Task<AddPersonPayload> AddPersonAsync(
            AddPersonInput input,
            [ScopedService] PersonContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = input.Name,
                Id = input.Id
            };
            
            dbContext.Persons?.Add(person);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddPersonPayload(person);
        }
    }
}