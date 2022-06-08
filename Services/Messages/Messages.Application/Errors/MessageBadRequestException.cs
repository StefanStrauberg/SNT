using BaseDomainEntity.Errors;

namespace Messages.Application.Errors
{
    public class MessageBadRequestException : BadRequestException
    {
        public MessageBadRequestException(string messageId) 
            : base($"The message with the identifier {messageId} was not found.")
        {
        }
    }
}