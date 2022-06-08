using BaseDomainEntity.Common;

namespace Companies.Application.DTOs
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Address { get; set; }
        public List<string> SocialLinks { get; set; } = new List<string>();
        public string Description { get; set; }
        public DateTime EstablishedSince { get; set; }
        public List<Guid> Posts { get; set; } = new List<Guid>();
    }
}
