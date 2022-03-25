using HotChocolate;
using HotChocolate.Types;

namespace Demo.Data
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Book OnBookReleased([EventMessage] Book book) => book;
    }
}