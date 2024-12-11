using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        void DeActive(T entity);
        void Active(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
