using BaseDomainEntity.Common;

namespace Messages.Domain
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        public Guid Receiver { get; set; }
        public Guid Recipient { get; set; }
        public bool Read { get; set; }
        public bool IsModified { get;set; }
    }
}