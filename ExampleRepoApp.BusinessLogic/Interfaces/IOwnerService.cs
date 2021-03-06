using System.Threading.Tasks;
using ExampleRepoApp.BusinessLogic.Domain;
using ExampleRepoApp.BusinessLogic.Models;

namespace ExampleRepoApp.BusinessLogic.Interfaces
{
    public interface IOwnerService : IService<Owner>
    {
        Task CreateOwner(CreateOwnerModel owner);
        Task<ExtendedOwner> GetExtendedOwnerById(long id);
        Task<Owner> GetOwnerByEmail(string email);
    }
}