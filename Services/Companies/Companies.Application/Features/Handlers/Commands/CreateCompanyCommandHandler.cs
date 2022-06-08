using AutoMapper;
using Companies.Application.Contracts;
using Companies.Application.Features.Requests.Commands;
using Companies.Domain;
using MediatR;

namespace Companies.Application.Features.Handlers.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Companies.Add(_mapper.Map<Company>(request.model));
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
