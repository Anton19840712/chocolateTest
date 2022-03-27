using System;
using System.Collections.Generic;
using AutoMapper;
using Demo.Models.PersonModels.BusinessPersonsDto;
using Demo.Models.PersonModels.DalPersonsDto;
using Demo.Models.PersonModels.ResponsePersonsDto;

namespace Demo.Infrastructure.Configuration.Mapping
{
    public class PersonMappingRules : Profile
    {

        public PersonMappingRules()
        {
            CreateMap<CreatePersonDto, PersonDalDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, CreatePersonDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, UpdatePersonDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<UpdatePersonDto, PersonDalDto >()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, PersonResponseDto>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;

            CreateMap<PersonDalDto, Person>()
                .ForMember(to => to.Gender, from => from.MapFrom(source => source.Gender))
                .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName))
                .ForMember(to => to.Email, from => from.MapFrom(source => source.Email))
                .ForMember(to => to.Score, from => from.MapFrom(source => source.Score))
                ;
        }
    }
}