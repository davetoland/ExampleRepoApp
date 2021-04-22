using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleRepoApp.BusinessLogic.Domain;
using ExampleRepoApp.BusinessLogic.Models;

namespace ExampleRepoApp.BusinessLogic.Interfaces
{
    public interface IVehicleService : IService<Vehicle>
    {
        Task CreateVehicle(CreateVehicleModel vehicle);
        Task<ExtendedVehicle> GetExtendedVehicleById(long id);
        Task<IEnumerable<Vehicle>> GetVehiclesByMake(string make);
        Task<IEnumerable<Vehicle>> GetVehiclesByModel(string model);
        Task<IEnumerable<Vehicle>> GetVehiclesByType(string typeName);
    }
}