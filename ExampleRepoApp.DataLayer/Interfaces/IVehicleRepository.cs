using System.Linq;
using ExampleRepoApp.DataLayer.Entities;

namespace ExampleRepoApp.DataLayer.Interfaces
{
    public interface IVehicleRepository : IRepository<ExampleVehicle>
    {
        IQueryable<ExampleVehicle> GetVehiclesByMake(string make);

        IQueryable<ExampleVehicle> GetVehiclesByModel(string model);

        IQueryable<ExampleVehicle> GetVehiclesByType(string typeName);
    }
}