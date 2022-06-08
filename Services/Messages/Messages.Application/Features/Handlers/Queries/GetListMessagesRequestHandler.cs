using AutoMapper;
using BaseDomainEntity.Specs;
using MediatR;
using Messages.Application.Contracts;
using Messages.Application.DTOs;
using Messages.Application.Features.Requests.Queries;
using Messages.Application.Specifications;

namespace Messages.Application.Features.Handlers.Queries
{
    public class GetListMessagesRequestHandler : IRequestHandler<GetListMessagesRequest, PagedList<MessageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetListMessagesRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<MessageDto>> Handle(GetListMessagesRequest request, CancellationToken cancellationToken)
        {
            var spec = new MessagesWithSpecification(request.querySpecParams);
            var messages = await _unitOfWork.Messages.GetAllWithSpecificationAsync(spec);
            return new PagedList<MessageDto>(
                items: _mapper.Map<List<MessageDto>>(messages),
                count: await _unitOfWork.Messages.CountAsync(spec),
                pageNumber: request.querySpecParams.PageIndex,
                pageSize: request.querySpecParams.PageSize
            );
        }
    }
}