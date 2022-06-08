using BaseDomainEntity.Errors;

namespace Jobs.Application.Errors
{
    public class JobBadRequestException : BadRequestException
    {
        public JobBadRequestException(string messageId)
            : base($"The job with the identifier {messageId} was not found.")
        {
        }
    }
}
