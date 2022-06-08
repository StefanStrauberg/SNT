using BaseDomainEntity.Specs;
using System.Linq.Expressions;

namespace Jobs.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T> specification = null);
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
