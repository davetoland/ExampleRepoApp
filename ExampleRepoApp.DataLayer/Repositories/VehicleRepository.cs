using System.Linq;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;

namespace ExampleRepoApp.DataLayer.Repositories
{
    public class VehicleRepository : AbstractRepository<ExampleVehicle>, IVehicleRepository
    {
        public VehicleRepository(ExampleRepoDbContext db) : base(db) { }

        public IQueryable<ExampleVehicle> GetVehiclesByMake(string make)
        {
            return Context.Vehicles.Where(x => x.Make == make);
        }

        public IQueryable<ExampleVehicle> GetVehiclesByModel(string model)
        {
            return Context.Vehicles.Where(x => x.Model == model);
        }

        public IQueryable<ExampleVehicle> GetVehiclesByType(string typeName)
        {
            return Context.Vehicles.Where(x => x.VehicleType.Name == typeName);
        }
    }
}