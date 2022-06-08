using BaseDomainEntity.Common;

namespace Jobs.Domain
{
    public class Job : BaseEntity
    {
        // Who Create
        public Guid UserId { get; set; }
        // Open or Close
        public bool Status { get; set; }
        public Guid CompanyId { get; set; }
        // Namin Project
        public string Title { get; set; }
        // Which Country is the company from
        public Country Country { get; set; }
        // Work Schedule
        public JobType JobType { get; set; }
        public int Salary { get; set; }
        public int TotalViewsCount { get; set; }
        // Job Description
        public string Body { get; set; }
        public List<string> WordsKey { get; set; }
        public List<Guid> Likes { get; set; }
    }
}