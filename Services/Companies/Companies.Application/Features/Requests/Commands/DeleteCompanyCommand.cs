using MediatR;

namespace Companies.Application.Features.Requests.Commands
{
    public record DeleteCompanyCommand(Guid id) : IRequest;
}
