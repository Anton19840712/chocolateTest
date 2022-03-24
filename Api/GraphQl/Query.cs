using Api.Model;
using Api.Database;

namespace Api.GraphQl
{
    public class Query
    {
        public string FirstName() => " Antonio";
        public string SecondName() => " Gridushko";
        public int Age() => 37;

        public Task<List<Book>> GetBooks([Service] Repository repository) =>
         repository.GetBooksAsync();
    }
}
