using System.Linq;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;

namespace ExampleRepoApp.DataLayer.Repositories
{
    public class OwnerAddressRepository : AbstractRepository<ExampleOwnerAddress>, IOwnerAddressRepository
    {
        public OwnerAddressRepository(ExampleRepoDbContext db) : base(db) { }

        public IQueryable<ExampleOwnerAddress> GetAddress(int number, string street, string city, string county, string postcode)
        {
            return Context.Addresses
                .Where(x => x.PostCode == postcode)
                .Where(x => x.County == county)
                .Where(x => x.City == city)
                .Where(x => x.StreetName == street)
                .Where(x => x.HouseNumber == number);
        }
    }
}