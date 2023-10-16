using FormatTCC.Core.Interfaces.Repositories;
using FormatTCC.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FormatTCC.Infrastructure.Persistence.Repositories
{
    public abstract class MainRepository<T> : IMainRepository<T> where T : class
    {

        private readonly ApplicationDbContext context;
        private readonly DbSet<T> db;

        public MainRepository(ApplicationDbContext context)
        {

            this.context = context;
            db = context.Set<T>();

        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate);
        }

        public IQueryable<T> GetAllQueryableAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate).AsNoTracking();
        }

        public async Task<T?> SingleOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return await db.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<T?> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await db.SingleOrDefaultAsync(predicate);
        }

        public async Task<T?> FindById(Guid id)
        {
            return await db.FindAsync(id);
        }

        public async Task Add(T item)
        {

            await db.AddAsync(item);
            await context.SaveChangesAsync();

        }

        public async Task AddRange(IEnumerable<T> items)
        {

            await db.AddRangeAsync(items);
            await context.SaveChangesAsync();

        }

        public void Update(T item)
        {
            db.Update(item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            db.UpdateRange(items);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await db.AnyAsync(predicate);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return db.Any(predicate);
        }
    }
}
