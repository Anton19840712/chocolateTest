using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.DataBaseContexts;
using Demo.Models.PersonModels.BusinessPersonsDto;
using Demo.Models.PersonModels.DalPersonsDto;
using Demo.Models.PersonModels.ResponsePersonsDto;
using HotChocolate;

namespace Demo.Repositories.PersonRepository
{
    /// <summary>
    /// Person mutation API 
    /// </summary>
    public class PersonMutation 
    {

        #region private fields
        private readonly IMapper _autoMapper;
        #endregion

        #region constructor
        public PersonMutation(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        #endregion

        #region graph ql api
        /// <summary>
        /// Api creates new instance of person.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponsePersonDto> SaveAsync([Service] PersonContext context, PersonDalDto model, CancellationToken cancellationToken)
        {
            context.Persons.Add(model);

            await context.SaveChangesAsync(cancellationToken);

            return _autoMapper.Map<ResponsePersonDto>(model);
        }
        /// <summary>
        /// Api deletes person instance.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponsePersonDto> DeleteAsync([Service] PersonContext dbContext, int id, CancellationToken cancellationToken)
        {
            var personDalDto = new PersonDalDto() { Id = id };

            dbContext.Persons?.Attach(personDalDto);

            dbContext.Persons?.Remove(personDalDto);

            await dbContext.SaveChangesAsync(cancellationToken);

            return _autoMapper.Map<ResponsePersonDto>(personDalDto);
        }

        /// <summary>
        /// Api update person instance
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="updateModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponsePersonDto> UpdateAsync([Service] PersonContext dbContext, PersonUpdateDto updateModel, CancellationToken cancellationToken)
        {
            var personDalDto = dbContext.Persons.SingleOrDefault(b => b.Id == updateModel.Id);

            if (personDalDto != null)
            {
                personDalDto.Email = updateModel.Email;

                personDalDto.FirstName = updateModel.FirstName;

                personDalDto.LastName = updateModel.LastName;

                personDalDto.Gender = updateModel.Gender;

                personDalDto.Score = updateModel.Score;

                dbContext.Persons.Update(personDalDto);

                await dbContext.SaveChangesAsync(cancellationToken);

                var personResponseDto = _autoMapper.Map<ResponsePersonDto>(personDalDto);

                return personResponseDto;
            }

            return new ResponsePersonDto();
        } 
        #endregion
    }
}