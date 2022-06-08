using AutoMapper;
using MediatR;
using Messages.Application.Contracts;
using Messages.Application.DTOs;
using Messages.Application.Errors;
using Messages.Application.Features.Requests.Commands;
using Messages.Domain;

namespace Messages.Application.Features.Handlers.Commands
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateMessageCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToUpdate = await _unitOfWork.Messages.GetByIdAsync(request.id);
            if (messageToUpdate is null)
                throw new MessageBadRequestException(request.id.ToString());
            _mapper.Map(request.model, messageToUpdate, typeof(UpdateMessageDto), typeof(Message));
            _unitOfWork.Messages.Update(messageToUpdate);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}