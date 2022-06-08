using System.Text.Json;
using BaseDomainEntity.Specs;
using MediatR;
using Messages.Application.DTOs;
using Messages.Application.Features.Requests.Commands;
using Messages.Application.Features.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Messages.API.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet]
        [ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMessages([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetListMessagesRequest(querySpecParams));
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
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdMessage(Guid id)
            => Ok(await _mediator.Send(new GetMessageRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto model)
            => Ok(await _mediator.Send(new CreateMessageCommand(model)));

        [HttpPut("{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageDto model, Guid id)
            => Ok(await _mediator.Send(new UpdateMessageCommand(model, id)));

        [HttpDelete("{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteMessage(Guid id)
            => Ok(await _mediator.Send(new DeleteMessageCommand(id)));
    }
}