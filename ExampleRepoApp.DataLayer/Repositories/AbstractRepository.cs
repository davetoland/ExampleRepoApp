using System.Linq;
using System.Threading.Tasks;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Exceptions;
using ExampleRepoApp.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleRepoApp.DataLayer.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : DbEntity
    {
        protected readonly ExampleRepoDbContext Context;

        protected AbstractRepository(ExampleRepoDbContext db)
        {
            Context = db;
        }

        public virtual async Task Add(T item)
        {
            var existing = GetById(item.Id).SingleOrDefault();
            if (existing != null)
                throw new RepositoryException($"{typeof(T).Name} with Id {item.Id} already exists");

            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        // This may seem strange, there can only be one entity per
        // id, but we still want to return an IQueryable in order
        // to respect deferred execution if it's required...
        
        // So therefore we still do a Where call, and then let
        // the caller execute a Single or SingleOrDefault after
        // doing a ProjectTo. Alternatively this also allows the 
        // caller to perform a Select in order to filter the 
        // properties in the entity, or perhaps create a different
        // DTO containing just one or a few of the properties.
        // This is particularly relevant for Entities that contain
        // a great many properties, and means the resulting query
        // on the database only SELECTs the fields that are actually
        // required, which is far more efficient than SELECTing the
        // entire row from the DB only to drop all but a few columns
        // when the Service populates a DTO.
        public virtual IQueryable<T> GetById(long id)
        {
            return Context.Set<T>().Where(x => x.Id == id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable();
        }

        public virtual async Task Update(T item)
        {
            try
            {
                Context.Entry(item).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new RepositoryException($"{typeof(T).Name} with Id {item.Id} does not exist");
            }
        }

        public virtual async Task Delete(long id)
        {
            var item = GetById(id).SingleOrDefault();
            if (item == null)
                throw new RepositoryException($"{typeof(T).Name} with Id {id} does not exist");

            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}