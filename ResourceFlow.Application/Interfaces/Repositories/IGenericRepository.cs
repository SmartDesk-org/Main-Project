using System.Linq.Expressions;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class

    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
        IQueryable<T> Queryable();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddRangeAsync(IEnumerable<T> entities);



    }  
  
}
