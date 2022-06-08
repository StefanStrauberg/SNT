using BaseDomainEntity.Specs;
using Companies.Domain;

namespace Companies.Application.Specifications
{
    public class CompaniesWithSpecification : BaseSpecification<Company>
    {
        public CompaniesWithSpecification(QuerySpecParams querySpecParams) : base(x =>
            (string.IsNullOrEmpty(querySpecParams.Search) || x.Name.ToLower().Contains(querySpecParams.Search)))
        {
            ApplyPaging(querySpecParams.PageSize * (querySpecParams.PageIndex - 1), querySpecParams.PageSize);
        }
    }
}
