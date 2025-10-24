using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.Interface;
using System.Collections;

namespace SchoolProject.Infrastructure.Implmention
{
    public class UnitOfWork(ApplicationDBContext dBContext) : IUniteOfWork
    {
        // A private Hashtable to cache repository instances.
        // This ensures we only create one repository instance per entity type.
        private Hashtable _repsitories = new Hashtable();

        Repository<T> IUniteOfWork.Repository<T>()
        {
            // Get the name of the entity type as a string key.
            var type = typeof(T).Name;

            // Check if a repository for this type is already cached.
            if (!_repsitories.ContainsKey(type))
            {
                // If not cached, get the type of the generic Repository<T>.
                var repositoryType = typeof(Repository<>);

                // Create a concrete instance of Repository<T> (e.g., Repository<Student>)
                // by making the generic type concrete and passing the dBContext to its constructor.
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), dBContext);

                // Add the newly created repository instance to the cache.
                _repsitories.Add(type, repositoryInstance);
            }

            // Return the cached repository instance, casting it to IRepository<T>.
            return (Repository<T>)_repsitories[type];
        }
        public async Task SaveChangesAsync()
        {
            await dBContext.SaveChangesAsync();
        }        
        Task<int> IUniteOfWork.SaveChangesAsync()
        {
            return dBContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            dBContext.Dispose();
        }
    }
}