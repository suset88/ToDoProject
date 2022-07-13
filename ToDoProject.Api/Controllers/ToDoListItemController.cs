using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Application.Models;
using ToDoProject.Application.Queries.ToDoListItem;

namespace ToDoProject.Api.Controllers
{
    [Route("api/ToDoListItem")]
    public class ToDoListItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoListItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> CreateToDoListItem([FromBody] CreateToDoListItemCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpGet]
        public async Task<List<ToDoListItem>> GetToDoListItems(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetToDoListItemsQuery(), cancellationToken);
        }

        [HttpPut]
        public async Task<bool> UpdateToDoListItem([FromBody] UpdateToDoListItemCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateToDoListItemCommand
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Status = command.Status
            }, cancellationToken);
        }

        [HttpDelete("{id:long:min(1)}")]
        public async Task<bool> DeleteToDoListItem([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteToDoListItemCommand { Id = id }, cancellationToken);
        }

        [HttpPut("{id:long:min(1)}/complete")]
        public async Task<bool> CompleteToDoListItem([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CompleteToDoListItemCommand
            {
                Id = id
            }, cancellationToken);
        }
    }
}
