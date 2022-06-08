using AutoMapper;
using MediatR;
using Messages.Application.Contracts;
using Messages.Application.Features.Requests.Commands;
using Messages.Domain;

namespace Messages.Application.Features.Handlers.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateMessageCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Messages.Add(_mapper.Map<Message>(request.model));
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}