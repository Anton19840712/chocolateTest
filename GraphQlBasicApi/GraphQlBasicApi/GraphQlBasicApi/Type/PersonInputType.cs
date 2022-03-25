using GraphQL.Types;

namespace GraphQlBasicApi.Type
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("country");
            Field<IntGraphType>("score");
            Field<StringGraphType>("phone");
        }
    }
}
