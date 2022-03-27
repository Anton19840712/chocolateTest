using GraphQL;
using GraphQL.Types;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Models;
using GraphQlBasicApi.Type;

namespace GraphQlBasicApi.Mutation
{
    public class PersonMutation : ObjectGraphType
    {
        public PersonMutation(IPersonCommand personCommandService)
        {

            Field<PersonType>("createPerson", 
                arguments: 
                new QueryArguments(new QueryArgument<PersonInputType>
                    {
                        Name = "person"
                    }
                ),

                resolve: context => 
                    personCommandService.AddPerson(context.GetArgument<Person>("person")));


            Field<PersonType>("updatePerson",
                arguments: 
                new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                new QueryArgument<PersonInputType> { Name = "person" }),

                resolve: context =>
                {
                    var personObj = context.GetArgument<Person>("person");

                    var personId = context.GetArgument<int>("id");

                    return personCommandService.UpdatePerson(personId, personObj);
                });


            Field<StringGraphType>("deletePerson",

                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),

                resolve: context =>
                {
                    var personId = context.GetArgument<int>("id");

                    personCommandService.DeletePerson(personId);

                    return "The person against the" + personId + "has been deleted";
                });
        }
    }
}