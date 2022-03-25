﻿using Demo.Data;
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
        [UseDbContext(typeof(BookContext))]
        public async Task<AddAuthorPayload> AddAuthorAsync(
            AddAuthorInput input,
            [ScopedService] BookContext dbContext)
        {
            var author = new Author
            {
                Name = input.Name
            };

            dbContext.Authors.Add(author);
            await dbContext.SaveChangesAsync();

            return new AddAuthorPayload(author);
        }

        [UseDbContext(typeof(BookContext))]
        public async Task<AddBookPayload> AddBookAsync(
            AddBookInput input,
            [ScopedService] BookContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = input.Title,
                AuthorId = input.AuthorId
            };

            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnBookReleased), book, cancellationToken);

            return new AddBookPayload(book);
        }
    }
}