using GraphQL.Types;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Type
{
    public sealed class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(p=>p.Id);
            Field(p => p.Name);
            Field(p => p.Country);
            Field(p => p.Score);
            Field(p => p.Phone);
        }
    }
}