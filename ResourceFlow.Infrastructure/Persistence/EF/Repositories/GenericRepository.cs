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


        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new  ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
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

   

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }


        public async Task UpdateAsync(T entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

         public IQueryable<T> Queryable()
        {
            return   _dbSet.AsQueryable();
        }
 
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }


    
}
