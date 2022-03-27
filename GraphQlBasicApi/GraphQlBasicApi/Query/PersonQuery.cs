using GraphQL;
using GraphQL.Types;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Type;

namespace GraphQlBasicApi.Query
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonCommand personCommandService, IPersonQuery personQueryService)
        {
            Field<ListGraphType<PersonType>>("persons", resolve: context => personCommandService.GetAllPersons());

            Field<PersonType>("person", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),

                resolve: context => personCommandService.GetPersonById(context.GetArgument<int>("id")));

            Field<ListGraphType<PersonType>>("topPersons", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "limit" }),

                resolve: context => personQueryService.GetTopPersons(context.GetArgument<int>("limit")));
        }
    }
}