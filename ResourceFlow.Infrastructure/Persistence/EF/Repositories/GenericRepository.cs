using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext db)
    {
        _db = db;
        _dbSet = db.Set<T>();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    // --------------------------
    // YOUR STYLE ✔ ASYNC UPDATE
    // --------------------------
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }


    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}
