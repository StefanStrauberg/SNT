using BaseDomainEntity.Common;

namespace Companies.Application.DTOs
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Address { get; set; }
        public int TotalEmployees { get; set; }
        public List<string> SocialLinks { get; set; }
        public string Description { get; set; }
        public DateTime EstablishedSince { get; set; }
        public List<Guid> Posts { get; set; }
        public List<Guid> Followers { get; set; }
        public int TotalCountFollowers { get; set; }
    }
}
