using Companies.Application.DTOs;
using MediatR;
namespace Companies.Application.Features.Requests.Commands
{
    public record UpdateCompanyCommand(UpdateCompanyDto model, Guid id) : IRequest;
}
