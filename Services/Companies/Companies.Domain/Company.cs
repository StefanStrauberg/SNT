using BaseDomainEntity.Common;

namespace Companies.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Address { get; set; }
        public int TotalEmployees { get; set; }
        private ISet<string> _socialLinks { get; set; } = new HashSet<string>();
        public IReadOnlyList<string> SocialLinks => _socialLinks.ToList();
        public string Description { get; set; }
        public DateTime EstablishedSince { get; set; }
        private ISet<Guid> _posts { get; set; } = new HashSet<Guid>();
        public IReadOnlyList<Guid> Posts => _posts.ToList();
        private ISet<Guid> _followers { get; set; } = new HashSet<Guid>();
        public IReadOnlyList<Guid> Followers => _followers.ToList();
        public int TotalCountFollowers
        {
            get
            {
                return Followers.Count;
            }
        }
    }
}
