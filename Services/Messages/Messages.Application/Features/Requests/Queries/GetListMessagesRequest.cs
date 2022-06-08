using BaseDomainEntity.Specs;
using MediatR;
using Messages.Application.DTOs;

namespace Messages.Application.Features.Requests.Queries
{
    public record GetListMessagesRequest(QuerySpecParams querySpecParams) : IRequest<PagedList<MessageDto>>;
}