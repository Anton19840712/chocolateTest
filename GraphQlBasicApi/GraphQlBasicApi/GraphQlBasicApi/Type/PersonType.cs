using GraphQL.Types;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Type
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("country");
            Field<FloatGraphType>("score");
            Field<FloatGraphType>("phone");
        }
    }
}