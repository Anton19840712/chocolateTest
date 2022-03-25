using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlBasicApi.Mutation;
using GraphQlBasicApi.Query;

namespace GraphQlBasicApi.Schema
{
    public class PersonSchema : GraphQL.Types.Schema
    {
        public PersonSchema(PersonQuery personQuery, PersonMutation personMutation)
        {
            Query = personQuery;

            Mutation = personMutation;
        }
    }
}