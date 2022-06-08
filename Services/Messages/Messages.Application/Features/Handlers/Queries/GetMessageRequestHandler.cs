using AutoMapper;
using MediatR;
using Messages.Application.Contracts;
using Messages.Application.DTOs;
using Messages.Application.Errors;
using Messages.Application.Features.Requests.Queries;

namespace Messages.Application.Features.Handlers.Queries
{
    public class GetMessageRequestHandler : IRequestHandler<GetMessageRequest, MessageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMessageRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MessageDto> Handle(GetMessageRequest request, CancellationToken cancellationToken)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(request.id);
            if (message is null)
                throw new MessageBadRequestException(request.id.ToString());
            return _mapper.Map<MessageDto>(message);
        }
    }
}