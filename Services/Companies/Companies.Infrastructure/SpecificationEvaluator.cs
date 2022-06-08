using BaseDomainEntity.Specs;
using Microsoft.EntityFrameworkCore;

namespace Companies.Infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static async Task<IEnumerable<TEntity>> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);
            if (spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);
            if (spec.OrderByDescending is not null)
                query = query.OrderByDescending(spec.OrderByDescending);
            if (spec.IsPagingEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);
            return await spec.Includes.Aggregate(query, (current, include) => current.Include(include)).ToListAsync();
        }
    }
}
