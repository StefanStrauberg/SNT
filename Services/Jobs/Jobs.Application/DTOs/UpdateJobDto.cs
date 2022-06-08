using Jobs.Domain;

namespace Jobs.Application.DTOs
{
    public class UpdateJobDto
    {
        public bool Status { get; set; }
        public string Title { get; set; }
        public JobType JobType { get; set; }
        public int Salary { get; set; }
        public int TotalViewsCount { get; set; }
        public string Body { get; set; }
        public List<string> WordsKey { get; set; }
        public List<Guid> Likes { get; set; }
    }
}
