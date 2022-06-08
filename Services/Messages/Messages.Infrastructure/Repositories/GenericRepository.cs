using System.Linq.Expressions;
using BaseDomainEntity.Specs;
using Messages.Application.Contracts;
using Messages.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Messages.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
            => _context = context;
        public async Task Add(T entity)
            => await _context.Set<T>().AddAsync(entity);
        public async Task<int> CountAsync(ISpecification<T> specification)
            => await _context.Set<T>().CountAsync();
        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T> specification = null)
            => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);
        public void Remove(T entity)
            => _context.Set<T>().Remove(entity);
        public void Update(T entity)
            => _context.Set<T>().Update(entity); 
    }
}