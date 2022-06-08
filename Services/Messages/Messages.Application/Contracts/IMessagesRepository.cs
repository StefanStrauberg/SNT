using Messages.Domain;

namespace Messages.Application.Contracts
{
    public interface IMessagesRepository : IGenericRepository<Message>
    {
    }
}