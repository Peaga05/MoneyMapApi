using Domain.Base.BaseEntity;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : FullEntity
    {
        private readonly MoneyMapDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MoneyMapDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void DeActive(T entity)
        {
            entity.Ativo = false;
            entity.DataDesativacao = DateTime.Now;
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Active(T entity)
        {
            entity.Ativo = true;
            entity.DataDesativacao = null;
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
