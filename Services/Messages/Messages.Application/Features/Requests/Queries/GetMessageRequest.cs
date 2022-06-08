using MediatR;
using Messages.Application.DTOs;

namespace Messages.Application.Features.Requests.Queries
{
    public record GetMessageRequest(Guid id) : IRequest<MessageDto>;
}