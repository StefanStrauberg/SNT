using AutoMapper;
using BaseDomainEntity.Specs;
using Companies.Application.Contracts;
using Companies.Application.DTOs;
using Companies.Application.Features.Requests.Queries;
using Companies.Application.Specifications;
using MediatR;

namespace Companies.Application.Features.Handlers.Queries
{
    public class GetListCompaniesRequestHandler : IRequestHandler<GetListCompaniesRequest, PagedList<CompanyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetListCompaniesRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<CompanyDto>> Handle(GetListCompaniesRequest request, CancellationToken cancellationToken)
        {
            var spec = new CompaniesWithSpecification(request.querySpecParams);
            var messages = await _unitOfWork.Companies.GetAllWithSpecificationAsync(spec);
            return new PagedList<CompanyDto>(
                items: _mapper.Map<List<CompanyDto>>(messages),
                count: await _unitOfWork.Companies.CountAsync(spec),
                pageNumber: request.querySpecParams.PageIndex,
                pageSize: request.querySpecParams.PageSize
            );
        }
    }
}
