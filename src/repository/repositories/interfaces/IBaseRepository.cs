using System.Linq.Expressions;

public interface IBaseRepository<T> : IDisposable where T : IEntityBase, new()
{
  Task<int> Create(T entity);
  Task<int> Update(T entity);
  Task<int> Delete(Guid id);
  Task<IList<T>> Read(Expression<Func<T, bool>> lambda);
  Task<T> GetById(Guid id);
}
