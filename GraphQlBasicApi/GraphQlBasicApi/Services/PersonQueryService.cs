using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlBasicApi.Data;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlBasicApi.Services
{
    public class PersonQueryService : IPersonQuery
    {
        private readonly PersonDbContext _dbContext;

        public PersonQueryService(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Person>> GetTopPersons(int limit)
        {
            return await _dbContext.Persons.Take(limit).ToListAsync();
        }
    }
}