using MediatR;
using Messages.Application.DTOs;

namespace Messages.Application.Features.Requests.Commands
{
    public record UpdateMessageCommand(UpdateMessageDto model, Guid id) : IRequest;
}