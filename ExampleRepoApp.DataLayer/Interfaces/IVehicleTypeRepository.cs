using System.Linq;
using ExampleRepoApp.DataLayer.Entities;

namespace ExampleRepoApp.DataLayer.Interfaces
{
    public interface IVehicleTypeRepository : IRepository<ExampleVehicleType>
    {
        IQueryable<ExampleVehicleType> GetVehicleTypesByName(string make);
    }
}