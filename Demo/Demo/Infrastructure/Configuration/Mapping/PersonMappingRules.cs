using AutoMapper;
using Demo.Models.PersonModels.BusinessPersonsDto;
using Demo.Models.PersonModels.DalPersonsDto;
using Demo.Models.PersonModels.ResponsePersonsDto;

namespace Demo.Infrastructure.Configuration.Mapping
{
    public class PersonMappingRules : Profile
    {
        /// <summary>
        /// Mapping rules for person models.
        /// </summary>
        public PersonMappingRules()
        {
            CreateMap<PersonCreateDto, PersonDalDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, PersonCreateDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, PersonUpdateDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonUpdateDto, PersonDalDto >()
                .ForMember(to => to.Id, from => from.MapFrom(source => source.Id))
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, ResponsePersonDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;
        }
    }
}