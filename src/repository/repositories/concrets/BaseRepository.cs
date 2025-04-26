using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.repository.repositories.concrets
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
  {
    protected readonly BaseContext _context;

    protected BaseRepository(BaseContext context)
    {
      _context = context;
    }

    public async Task<int> Create(T entity)
    {
      _context.Set<T>().Add(entity);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid id)
    {
      _context.Remove(id);

      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public async Task<T> GetById(Guid id)
    {
      return await _context.Set<T>().FirstAsync(entity => entity.Id.Equals(id));
    }

    public async Task<IList<T>> Read(Expression<Func<T, bool>> lambda)
    {
      lambda.Compile();
      return await _context.Set<T>().Where(lambda).ToListAsync();
    }

    public async Task<int> Update(T entity)
    {
      if (GetById(entity.Id) == null)
      {
        return 0;
      }
      _context.Attach(entity);
      _context.Update(entity);
      return await _context.SaveChangesAsync();
    }
  }
}
