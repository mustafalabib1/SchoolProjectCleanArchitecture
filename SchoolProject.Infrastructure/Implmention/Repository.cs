using SchoolProject.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore; // Add this using statement
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Implmention
{
    public class Repository<T>(ApplicationDBContext dBContext) : IRepository<T> where T : BaseEntity
    {
        // Adds a new entity to the database
        async Task IRepository<T>.AddAsync(T entity)
        {
            await dBContext.Set<T>().AddAsync(entity);
        }

        // Finds an entity by its ID, removes it.
        async Task IRepository<T>.DeleteAsync(Guid id)
        {
            var entity = await dBContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                dBContext.Set<T>().Remove(entity);
            }
            // If entity is null, it's already gone.
        }

        // Retrieves all entities of type T from the database
        async Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
        {
            return await dBContext.Set<T>().AsNoTracking().ToListAsync();
        }

        // Finds a single entity by its primary key (ID)
        async Task<T> IRepository<T>.GetByIdAsync(Guid id)
        {
            // FindAsync is optimized for finding by primary key
            return await dBContext.Set<T>().FindAsync(id);
        }

        // Attaches an entity, marks it as modified.
        async Task IRepository<T>.UpdateAsync(T entity)
        {
            dBContext.Set<T>().Update(entity);
        }

        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> filter)
        {
            // Assuming dBContext is your database context and it has a DbSet<T> for the entity type T.
            return await Task.FromResult(dBContext.Set<T>().Where(filter));
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            // Apply the specification to the context to retrieve the entity
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            // Apply the specification to the context and retrieve the entities
            return await ApplySpec(spec).AsNoTracking().ToListAsync();
        }

        //helper
        private IQueryable<T> ApplySpec(ISpecification<T> spec) => SpecificationEvaluator<T>.GetQuery(dBContext.Set<T>(), spec);

    }
}