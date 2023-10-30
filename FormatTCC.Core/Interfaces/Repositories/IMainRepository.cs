using System.Linq.Expressions;

namespace FormatTCC.Core.Interfaces.Repositories
{
    public interface IMainRepository<T> where T : class
    {

        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllQueryableAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<T?> SingleOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<T?> SingleOrDefault(Expression<Func<T, bool>> predicate);
        Task<T?> FindById(Guid id);
        Task Add(T item);
        Task AddRange(IEnumerable<T> items);
        void Update(T item);
        void UpdateRange(IEnumerable<T> items);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    }
}
