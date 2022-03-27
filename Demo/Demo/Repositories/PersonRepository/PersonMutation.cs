using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.DataBaseContexts;
using Demo.Models.PersonModels.BusinessPersonsDto;
using Demo.Models.PersonModels.DalPersonsDto;
using Demo.Models.PersonModels.ResponsePersonsDto;
using HotChocolate;
using HotChocolate.Data;

namespace Demo.Repositories.PersonRepository
{

    public class Mutation 
    {
        private readonly IMapper _autoMapper;

        public Mutation(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public PersonResponseDto AddPerson
        (
            [ScopedService] PersonContext personContext,
            CreatePersonDto input,
            CancellationToken cancellationToken)
        {
            var personDalModel = _autoMapper.Map<PersonDalDto>(input);

            var person = _autoMapper.Map<Person>(personDalModel);

            personContext.Persons?.Add(personDalModel);

            personContext.SaveChanges();

            var personResponseDto = _autoMapper.Map<PersonResponseDto>(personDalModel);

            return personResponseDto;
        }

        [UseDbContext(typeof(PersonContext))]
        public async Task<PersonResponseDto> UpdatePersonAsync
        (
            UpdatePersonDto updateModel,
            [ScopedService] PersonContext dbContext,
            CancellationToken cancellationToken)
        {
            var personDalDto = dbContext.Persons?.SingleOrDefault(b => b.Id == updateModel.Id);

            if (personDalDto != null)
            {
                var personDalModelDto = _autoMapper.Map<PersonDalDto>(updateModel);

                dbContext.Persons?.Update(personDalModelDto);

                await dbContext.SaveChangesAsync(cancellationToken);

                var personResponseDto = _autoMapper.Map<PersonResponseDto>(personDalModelDto);

                return personResponseDto;
            }
            
            return new PersonResponseDto();
        }


        [UseDbContext(typeof(PersonContext))]
        public async Task DeletePersonAsync
        (
            int id,
            [ScopedService] PersonContext dbContext,
            CancellationToken cancellationToken)
        {
            var personDalDto = new PersonDalDto(){ Id = id };

            dbContext.Persons?.Attach(personDalDto);

            dbContext.Persons?.Remove(personDalDto);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}