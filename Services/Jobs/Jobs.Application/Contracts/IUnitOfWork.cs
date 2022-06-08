namespace Jobs.Application.Contracts
{
    public interface IUnitOfWork
    {
        IJobRepository Jobs { get; }
        Task<int> Complete();
    }
}
