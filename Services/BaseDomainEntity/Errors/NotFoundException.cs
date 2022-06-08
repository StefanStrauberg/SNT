namespace BaseDomainEntity.Errors
{
    public class NotFoundException : ApplicationException
    {
        protected NotFoundException(string message) 
            : base("Not Found", message)
        {
        }
    }
}