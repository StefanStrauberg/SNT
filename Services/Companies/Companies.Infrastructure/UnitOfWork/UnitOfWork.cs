using Companies.Application.Contracts;
using Companies.Infrastructure.Configurations;
using Companies.Infrastructure.Repositories;

namespace Companies.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompaniesRepository(_context);
        }
        public ICompaniesRepository Companies { get; private set; }
        public async Task<int> Complete()
            => await _context.SaveChangesAsync();
        public async void Dispose()
            => await _context.DisposeAsync();
    }
}
