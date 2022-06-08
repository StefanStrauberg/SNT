namespace Companies.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICompaniesRepository Companies { get; }
        Task<int> Complete();
    }
}
