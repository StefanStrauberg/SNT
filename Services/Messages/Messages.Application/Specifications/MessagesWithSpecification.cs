using BaseDomainEntity.Specs;
using Messages.Domain;

namespace Messages.Application.Specifications
{
    public class MessagesWithSpecification : BaseSpecification<Message>
    {
        public MessagesWithSpecification(QuerySpecParams querySpecParams) : base(x =>
            (string.IsNullOrEmpty(querySpecParams.Search) || x.Body.ToLower().Contains(querySpecParams.Search)))
        {
            ApplyPaging(querySpecParams.PageSize * (querySpecParams.PageIndex - 1), querySpecParams.PageSize);
        }
    }
}