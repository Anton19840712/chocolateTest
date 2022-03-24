using Api.Model;
using Api.Database;
using HotChocolate.AspNetCore.Authorization;
namespace Api.GraphQl

{
    public class Mutation
    {
        //[Authorize(Policy = "Librarian")]
        //You may ask why AddAuthor returns an AddAuthorPayload and not just the Author directly.
        //This is a GraphQl convention that helps you adjust the schema in the future without a breaking change.
        public async Task<AuthorPayload> AddAuthor(AuthorInput input, [Service] Repository repository)
        {
            var author = new Author(Guid.NewGuid(), input.Name);

            await repository.AddAuthor(author);

            return new AuthorPayload(author);
        }

        public async Task<BookPayload> AddBook(BookInput input, [Service] Repository repository)
        {
            var author = await repository.GetAuthor(input.Author) ??
                            throw new AuthorNotFoundException("Author not found");

            var book = new Book(Guid.NewGuid(), input.Title, author);

            await repository.AddBook(book);

            return new BookPayload(book);
        }
    }

    public record BookPayload(Book? Record, string? Error = null) : Payload(Error);
    public record BookInput(string Title, Guid Author);
    public record AuthorPayload(Author? Record, string? Error = null) : Payload(Error);
    public record AuthorInput(string Name);
    public record Payload(string? Error);
}