namespace Messages.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IMessagesRepository Messages { get; }
        Task<int> Complete();
    }
}