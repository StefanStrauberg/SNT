namespace Messages.Application.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } 
        public DateTime? ModifeiedTime { get; set; }
        public string Body { get; set; }
        public Guid Receiver { get; set; }
        public Guid Recipient { get; set; }
        public bool Read { get; set; } = false;
        public bool IsModified { get;set; }
    }
}