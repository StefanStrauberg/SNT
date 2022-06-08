using MediatR;
using Messages.Application.DTOs;

namespace Messages.Application.Features.Requests.Commands
{
    public record CreateMessageCommand(CreateMessageDto model) : IRequest;
}