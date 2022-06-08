using Messages.Application.Contracts;
using Messages.Infrastructure.Configurations;
using Messages.Infrastructure.Repositories;

namespace Messages.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Messages = new MessagesRepository(_context);
        }
        public IMessagesRepository Messages { get; private set; }
        public async Task<int> Complete()
            => await _context.SaveChangesAsync();
        public async void Dispose()
            => await _context.DisposeAsync();
    }
}