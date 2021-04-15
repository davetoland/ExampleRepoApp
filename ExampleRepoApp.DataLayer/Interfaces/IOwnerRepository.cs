using System.Linq;
using ExampleRepoApp.DataLayer.Entities;

namespace ExampleRepoApp.DataLayer.Interfaces
{
    public interface IOwnerRepository : IRepository<ExampleOwner>
    {
        IQueryable<ExampleOwner> GetOwnerByEmailAddress(string email);
    }
}