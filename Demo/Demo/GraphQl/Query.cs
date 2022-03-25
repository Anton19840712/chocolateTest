using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.GraphQl
{
    public class Query
    {
        public string SayHello(string? name = "Antonio") => $"Here I am! My name is {name}";
        public string SayName(string? name = "Irina") => $"The name is {name}";

        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] BookContext dbContext) =>
            dbContext.Books;


        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] BookContext dbContext) =>
            dbContext.Authors;

        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public Task<Author> GetAuthorByIdAsync(int id, [ScopedService] BookContext dbContext) =>
            dbContext.Authors.FirstOrDefaultAsync(t => t.Id == id);
    }
}