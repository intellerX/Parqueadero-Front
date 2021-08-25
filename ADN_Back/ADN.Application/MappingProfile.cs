using AutoMapper;

namespace ADN.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ADN.Domain.Entities.Person, ADN.Application.Person.Queries.PersonDto>();
            CreateMap<ADN.Application.Person.Queries.PersonDto, ADN.Domain.Entities.Person>();           
        }
    }
}
