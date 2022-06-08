namespace Messages.Application.DTOs
{
    public class UpdateMessageDto
    {
        public string Body { get; set; }
        public Guid Receiver { get; set; }
        public Guid Recipient { get; set; }
    }
}