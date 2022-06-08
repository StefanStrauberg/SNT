using Messages.Application.Contracts;
using Messages.Domain;
using Messages.Infrastructure.Configurations;

namespace Messages.Infrastructure.Repositories
{
    public class MessagesRepository : GenericRepository<Message>, IMessagesRepository
    {
        public MessagesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}