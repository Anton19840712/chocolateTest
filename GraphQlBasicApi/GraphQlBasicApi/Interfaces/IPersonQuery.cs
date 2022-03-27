using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Interfaces
{
    public interface IPersonQuery
    {
        Task <List<Person>> GetTopPersons(int limit);
    }
}