using BaseDomainEntity.Errors;

namespace Messages.Application.Errors
{
    public class MessageNotFoundException : NotFoundException
    {
        public MessageNotFoundException(string messageId) 
            : base($"The message with the identifier {messageId} was not found.")
        {
        }
    }
}