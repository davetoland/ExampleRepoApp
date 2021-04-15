using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleRepoApp.BusinessLogic.Interfaces
{
    public interface IService<T>
    {
        public Task<T> GetById(long id);
        public Task<IEnumerable<T>> GetAll();
        public Task Delete(long id);
    }
}