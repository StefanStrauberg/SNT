using BaseDomainEntity.Specs;
using Companies.Application.DTOs;
using MediatR;

namespace Companies.Application.Features.Requests.Queries
{
    public record GetListCompaniesRequest(QuerySpecParams querySpecParams) : IRequest<PagedList<CompanyDto>>;
}
