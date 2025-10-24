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
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> filter);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec);
    }

}
