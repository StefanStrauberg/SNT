using BaseDomainEntity.Specs;
using Companies.Application.DTOs;
using Companies.Application.Features.Requests.Commands;
using Companies.Application.Features.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Companies.API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(List<CompanyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCompany([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetListCompaniesRequest(querySpecParams));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            }));
            return Ok(result);
        }

        [HttpGet("{id:length(36)}")]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdCompany(Guid id)
            => Ok(await _mediator.Send(new GetCompanyRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto model)
            => Ok(await _mediator.Send(new CreateCompanyCommand(model)));

        [HttpPut("{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyDto model, Guid id)
            => Ok(await _mediator.Send(new UpdateCompanyCommand(model, id)));

        [HttpDelete("{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCompany(Guid id)
            => Ok(await _mediator.Send(new DeleteCompanyCommand(id)));
    }
}
