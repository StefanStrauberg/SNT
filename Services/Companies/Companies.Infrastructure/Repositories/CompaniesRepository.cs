using Companies.Application.Contracts;
using Companies.Domain;
using Companies.Infrastructure.Configurations;

namespace Companies.Infrastructure.Repositories
{
    public class CompaniesRepository : GenericRepository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
