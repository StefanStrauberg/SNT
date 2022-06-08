using AutoMapper;
using Companies.Application.DTOs;
using Companies.Domain;

namespace Companies.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();
            CreateMap<Company, CompanyDto>();
        }
    }
}
