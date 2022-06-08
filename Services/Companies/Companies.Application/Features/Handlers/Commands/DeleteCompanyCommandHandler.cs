using AutoMapper;
using Companies.Application.Contracts;
using Companies.Application.Errors;
using Companies.Application.Features.Requests.Commands;
using MediatR;

namespace Companies.Application.Features.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCompanyCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _unitOfWork.Companies.GetByIdAsync(request.id);
            if (companyToDelete is null)
                throw new CompanyBadRequestException(request.id.ToString());
            _unitOfWork.Companies.Remove(companyToDelete);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
