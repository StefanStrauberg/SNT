using AutoMapper;
using Companies.Application.Contracts;
using Companies.Application.DTOs;
using Companies.Application.Errors;
using Companies.Application.Features.Requests.Commands;
using Companies.Domain;
using MediatR;

namespace Companies.Application.Features.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCompanyCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _unitOfWork.Companies.GetByIdAsync(request.id);
            if (companyToUpdate is null)
                throw new CompanyBadRequestException(request.id.ToString());
            _mapper.Map(request.model, companyToUpdate, typeof(UpdateCompanyDto), typeof(Company));
            _unitOfWork.Companies.Update(companyToUpdate);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
