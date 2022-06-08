using AutoMapper;
using Companies.Application.Contracts;
using Companies.Application.DTOs;
using Companies.Application.Errors;
using Companies.Application.Features.Requests.Queries;
using MediatR;

namespace Companies.Application.Features.Handlers.Queries
{
    public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, CompanyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCompanyRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompanyDto> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(request.id);
            if (company is null)
                throw new CompanyBadRequestException(request.id.ToString());
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
