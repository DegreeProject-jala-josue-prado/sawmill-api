using System.Linq.Expressions;
using yume_api.src.repository.entities;

namespace yume_api.src.repository.repositories.interfaces
{
  public interface IBaseRepository<T> : IDisposable where T : IEntityBase, new()
  {
    Task<int> Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(Guid id);
    Task<IList<T>> Read(Expression<Func<T, bool>> lambda);
    Task<T> GetById(Guid id);
  }
}
