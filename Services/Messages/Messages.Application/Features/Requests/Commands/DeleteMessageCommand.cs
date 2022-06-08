using MediatR;

namespace Messages.Application.Features.Requests.Commands
{
    public record DeleteMessageCommand(Guid id) : IRequest;
}