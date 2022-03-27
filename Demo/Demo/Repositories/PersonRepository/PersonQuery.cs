using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.DataBaseContexts;
using Demo.Models.PersonModels.DalPersonsDto;
using Demo.Models.PersonModels.ResponsePersonsDto;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.PersonRepository
{
    /// <summary>
    /// Person query API
    /// </summary>
    public class PersonQuery
    {
        #region private fields
        private readonly IMapper _autoMapper;
        #endregion

        #region constructor
        public PersonQuery(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        #endregion


        #region smoke api
        public string SayHello(string name = "Antonio") => $"Here I am! My name is {name}";
        public string SayName(string name = "Irina") => $"The name is {name}";
        #endregion

        #region query person api
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public List<PersonDalDto> GetPersons([Service] PersonContext dbContext)
        {
            var model = dbContext.Persons.ToList();

            return model;
        }

        /// <summary>
        /// Get person by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public async Task<ResponsePersonDto> GetPersonByIdAsync(int id, [Service] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? _autoMapper.Map<ResponsePersonDto>((await dbContext.Persons.FirstOrDefaultAsync(t => t.Id == id)))
                : new ResponsePersonDto();
        }
        /// <summary>
        /// Get persons by list of ids.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public async Task<List<ResponsePersonDto>> GetPersonsIdsAsync(List<int> ids, [Service] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? (await dbContext.Persons.Where(s => ids.Contains(s.Id)).ToListAsync())
                .Select(x => _autoMapper.Map<ResponsePersonDto>(x))
                .ToList()
                : new List<ResponsePersonDto>();
        }
        /// <summary>
        /// Get persons with score more than.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public async Task<List<ResponsePersonDto>> GetPersonsScoreGreaterAsync(int number, [Service] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? (await dbContext.Persons.Where(s => s.Score > number).ToListAsync())
                .Select(x => _autoMapper.Map<ResponsePersonDto>(x))
                .ToList()

                : new List<ResponsePersonDto>();
        }
        /// <summary>
        /// Get persons with score less than.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public async Task<List<ResponsePersonDto>> GetPersonsScoreLessAsync(int number, [Service] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? (await dbContext.Persons.Where(s => s.Score < number).ToListAsync())
                .Select(x => _autoMapper.Map<ResponsePersonDto>(x))
                .ToList()
                : new List<ResponsePersonDto>();
        }
        /// <summary>
        /// Get persons with names starts with.
        /// </summary>
        /// <param name="nameStartElement"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public async Task<List<ResponsePersonDto>> GetPersonsNameStartsAsync(string nameStartElement, [Service] PersonContext dbContext)
        {
            return dbContext.Persons != null
                ? (await dbContext.Persons.Where(x => x.FirstName != null && x.FirstName.StartsWith(nameStartElement)).ToListAsync())
                .Select(x => _autoMapper.Map<ResponsePersonDto>(x))
                .ToList()
                : new List<ResponsePersonDto>();
        } 
        #endregion
    }
}