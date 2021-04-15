using AutoMapper;
using ExampleRepoApp.BusinessLogic.Models;
using ExampleRepoApp.DataLayer.Entities;

namespace ExampleRepoApp.BusinessLogic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOwnerModel, ExampleOwner>();
            CreateMap<CreateVehicleModel, ExampleVehicle>()
                .ForMember(dest => dest.VehicleType, src => src.Ignore());
            
            CreateMap<ExampleOwner, Domain.Owner>();
            CreateMap<Domain.Owner, ExampleOwner>();
            
            CreateMap<ExampleOwnerAddress, Domain.OwnerAddress>();
            CreateMap<Domain.OwnerAddress, ExampleOwnerAddress>();

            CreateMap<ExampleVehicle, Domain.Vehicle>()
                .ForMember(dest => dest.VehicleType, src => src.MapFrom(x => x.VehicleType.Name));
            CreateMap<Domain.Vehicle, ExampleVehicle>(); 
        }
    }
}