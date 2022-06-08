using Companies.Application.DTOs;
using MediatR;

namespace Companies.Application.Features.Requests.Commands
{
    public record CreateCompanyCommand(CreateCompanyDto model) : IRequest;
}
