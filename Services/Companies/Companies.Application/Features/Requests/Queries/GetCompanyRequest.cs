using Companies.Application.DTOs;
using MediatR;

namespace Companies.Application.Features.Requests.Queries
{
    public record GetCompanyRequest(Guid id) : IRequest<CompanyDto>;
}
