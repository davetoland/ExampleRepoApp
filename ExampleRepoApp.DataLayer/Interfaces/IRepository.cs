using System.Linq;
using System.Threading.Tasks;

namespace ExampleRepoApp.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        Task Add(T item);
        IQueryable<T> GetById(long id);
        IQueryable<T> GetAll();
        Task Update(T item);  
        Task Delete(long id);
    }
}