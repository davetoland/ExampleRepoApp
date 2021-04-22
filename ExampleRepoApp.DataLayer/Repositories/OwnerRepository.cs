using System.Linq;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;

namespace ExampleRepoApp.DataLayer.Repositories
{
    public class OwnerRepository : AbstractRepository<ExampleOwner>, IOwnerRepository
    {
        public OwnerRepository(ExampleRepoDbContext db) : base(db) { }
        
        public IQueryable<ExampleOwner> GetOwnerByEmailAddress(string email)
        {
            return Context.Owners.Where(x => x.EmailAddress == email);
        }

        public override IQueryable<ExampleOwner> GetById(long id)
        {
            return Context.Owners.Where(x => x.Id == id);
        }
    }
}