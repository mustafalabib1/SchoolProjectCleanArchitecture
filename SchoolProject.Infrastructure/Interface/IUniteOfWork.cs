using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Implmention;

namespace SchoolProject.Infrastructure.Interface
{
    public interface IUniteOfWork : IDisposable
    {
        Repository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }

}
