using SchoolProject.Infrastructure.Specification;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(Guid id);
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);
        public Task<IQueryable<T>> Find(Expression<Func<T, bool>> filter); 
        public Task<T> GetEntityWithSpec(ISpecification<T> spec);
        public Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec);
    }

}
