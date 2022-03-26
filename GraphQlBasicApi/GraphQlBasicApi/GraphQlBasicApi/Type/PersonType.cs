using GraphQL.Types;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Type
{
    public sealed class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(p=>p.Id);
            Field(p => p.Gender);
            Field(p => p.FirstName);
            Field(p => p.LastName);
            Field(p => p.Email);
            Field(p => p.Score);
        }
    }
}