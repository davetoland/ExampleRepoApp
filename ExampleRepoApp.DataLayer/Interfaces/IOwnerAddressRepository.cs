using System.Linq;
using ExampleRepoApp.DataLayer.Entities;

namespace ExampleRepoApp.DataLayer.Interfaces
{
    public interface IOwnerAddressRepository : IRepository<ExampleOwnerAddress>
    {
        public IQueryable<ExampleOwnerAddress> GetAddress (int number, string street, string city, string county, string postcode);
    }
}