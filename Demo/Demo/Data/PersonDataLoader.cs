using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class PersonDataLoader : BatchDataLoader<int, Person>
    {
        private readonly IDbContextFactory<PersonContext> _contextFactory;

        public PersonDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<PersonContext> contextFactory)
            : base(batchScheduler)
        {
            _contextFactory = contextFactory;
        }

        protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using PersonContext context = _contextFactory.CreateDbContext();

                var result = (await context.Persons
                .Where(t => keys.Contains(t.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken));

                return result;
        }
    }
}