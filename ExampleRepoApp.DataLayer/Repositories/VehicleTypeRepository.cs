using System.Linq;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;

namespace ExampleRepoApp.DataLayer.Repositories
{
    public class VehicleTypeRepository : AbstractRepository<ExampleVehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(ExampleRepoDbContext db) : base(db) { }

        public IQueryable<ExampleVehicleType> GetVehicleTypesByName(string name)
        {
            return Context.VehicleTypes.Where(x => x.Name == name);
        }
    }
}