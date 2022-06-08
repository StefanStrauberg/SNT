using BaseDomainEntity.Errors;

namespace Companies.Application.Errors
{
    public class CompanyBadRequestException : BadRequestException
    {
        public CompanyBadRequestException(string messageId)
            : base($"The company with the identifier {messageId} was not found.")
        {
        }
    }
}
