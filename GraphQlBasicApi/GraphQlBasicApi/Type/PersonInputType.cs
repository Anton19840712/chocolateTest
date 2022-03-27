using GraphQL.Types;

namespace GraphQlBasicApi.Type
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Field<StringGraphType>("gender");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            Field<StringGraphType>("email");
            Field<IntGraphType>("score");
        }
    }
}
