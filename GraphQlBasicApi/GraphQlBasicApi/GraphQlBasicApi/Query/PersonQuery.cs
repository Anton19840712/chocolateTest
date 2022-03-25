using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Type;

namespace GraphQlBasicApi.Query
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPerson personService)
        {
            Field<ListGraphType<PersonType>>("persons", resolve: context => personService.GetAllPersons());

            Field<PersonType>("person", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),

                resolve: context => personService.GetPersonById(context.GetArgument<int>("id")));
        }
    }
}