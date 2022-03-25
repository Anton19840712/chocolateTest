using Demo.Data;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor
                .Field(t => t.Author)
                .ResolveWith<Resolvers>(t => t.GetAuthorAsync(default!, default!, default!))
                .UseDbContext<BookContext>();
        }

        private class Resolvers
        {
            public Task<Author> GetAuthorAsync(
                Book book,
                AuthorDataLoader authorById,
                CancellationToken cancellationToken) =>
                authorById.LoadAsync(book.AuthorId, cancellationToken);
        }
    }
}