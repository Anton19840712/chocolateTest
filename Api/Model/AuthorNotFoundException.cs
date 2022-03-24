namespace Api.Model
{
    public class AuthorNotFoundException : DomainException
    {
        public AuthorNotFoundException() { }

        public AuthorNotFoundException(string? message) : base(message) { }

        public AuthorNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
