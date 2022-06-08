using BaseDomainEntity.Errors;

namespace Jobs.Application.Errors
{
    public class JobNotFoundException : NotFoundException
    {
        public JobNotFoundException(string messageId)
            : base($"The job with the identifier {messageId} was not found.")
        {
        }
    }
}
