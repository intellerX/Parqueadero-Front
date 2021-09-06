using AutoMapper;

namespace ADN.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ADN.Domain.Entities.Vehicle, ADN.Application.Vehicle.Queries.VehicleDto>();
            CreateMap<ADN.Application.Vehicle.Queries.VehicleDto, ADN.Domain.Entities.Vehicle>();

        }
    }
}
