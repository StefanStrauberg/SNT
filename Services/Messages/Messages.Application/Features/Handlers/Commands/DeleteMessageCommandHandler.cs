using MediatR;
using Messages.Application.Contracts;
using Messages.Application.Errors;
using Messages.Application.Features.Requests.Commands;

namespace Messages.Application.Features.Handlers.Commands
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteMessageCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToDelete = await _unitOfWork.Messages.GetByIdAsync(request.id);
            if (messageToDelete is null)
                throw new MessageBadRequestException(request.id.ToString());
            _unitOfWork.Messages.Remove(messageToDelete);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}