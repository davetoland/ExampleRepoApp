using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExampleRepoApp.BusinessLogic.Domain;
using ExampleRepoApp.BusinessLogic.Models;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleRepoApp.BusinessLogic.Services
{
    public class VehicleService : AbstractService<ExampleVehicle, Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IVehicleTypeRepository _typeRepo;

        public VehicleService(IVehicleRepository vehicleRepo, IVehicleTypeRepository typeRepo, IMapper mapper)
            : base(vehicleRepo, mapper)
        {
            _vehicleRepo = vehicleRepo;
            _typeRepo = typeRepo;
        }

        public async Task CreateVehicle(CreateVehicleModel vehicle)
        {
            var vehicleType = await _typeRepo
                .GetVehicleTypesByName(vehicle.VehicleType)
                .SingleOrDefaultAsync();

            if (vehicleType == null)
            {
                vehicleType = new ExampleVehicleType { Name = vehicle.VehicleType };
                await _typeRepo.Add(vehicleType);
            }

            var entity = Mapper.Map<ExampleVehicle>(vehicle);
            entity.VehicleType = vehicleType;
            await _vehicleRepo.Add(entity);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByMake(string make)
        {
            return await _vehicleRepo.GetVehiclesByMake(make)
                .ProjectTo<Vehicle>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByModel(string model)
        {
            return await _vehicleRepo.GetVehiclesByModel(model)
                .ProjectTo<Vehicle>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByType(string typeName)
        {
            return await _vehicleRepo.GetVehiclesByType(typeName)
                .ProjectTo<Vehicle>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}