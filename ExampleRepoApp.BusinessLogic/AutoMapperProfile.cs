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

            CreateMap<ExampleOwner, Domain.ExtendedOwner>()
                ;//.ForAllMembers(src => src.ExplicitExpansion());
            CreateMap<Domain.ExtendedOwner, ExampleOwner>();
            
            CreateMap<ExampleOwnerAddress, Domain.OwnerAddress>()
                ;//.ForAllMembers(src => src.ExplicitExpansion());
            CreateMap<Domain.OwnerAddress, ExampleOwnerAddress>();

            CreateMap<ExampleVehicle, Domain.Vehicle>()
                .ForMember(dest => dest.VehicleType, src => src.MapFrom(x => x.VehicleType.Name))
                ;//.ForAllMembers(src => src.ExplicitExpansion());
            CreateMap<Domain.Vehicle, ExampleVehicle>(); 
        }
    }
}