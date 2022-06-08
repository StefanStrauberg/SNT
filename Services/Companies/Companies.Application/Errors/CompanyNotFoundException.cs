using BaseDomainEntity.Errors;

namespace Companies.Application.Errors
{
    public class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(string messageId)
            : base($"The company with the identifier {messageId} was not found.")
        {
        }
    }
}
