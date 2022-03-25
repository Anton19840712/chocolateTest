using GraphQL.Types;

namespace GraphQlBasicApi.Type
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("country");
            Field<FloatGraphType>("score");
            Field<FloatGraphType>("phone");
        }
    }
}
