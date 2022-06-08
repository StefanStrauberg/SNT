using BaseDomainEntity.Common;
using Jobs.Domain;

namespace Jobs.Application.DTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifeiedTime { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }
        public Guid CompanyId { get; set; }
        public string Title { get; set; }
        public Country Country { get; set; }
        public JobType JobType { get; set; }
        public int Salary { get; set; }
        public int TotalViewsCount { get; set; }
        public string Body { get; set; }
        public List<string> WordsKey { get; set; }
        public List<Guid> Likes { get; set; }
    }
}
