using System;
namespace BaseDomainEntity.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModifeiedTime { get; set; } = null;
    }
}