using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Application.Models;
using ToDoProject.Application.Queries.ToDoList;

namespace ToDoProject.Api.Controllers
{
    [Route("api/ToDoList")]
    public class ToDoListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> CreateToDoList([FromBody] CreateToDoListCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpGet]
        public async Task<List<ToDoList>> GetToDoLists(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetToDoListsQuery(), cancellationToken);
        }

        [HttpGet("{user}")]
        public async Task<List<ToDoList>> GetToDoListsByUser([FromRoute] string user, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetToDoListByUserQuery { User = user }, cancellationToken);
        }

        [HttpPut]
        public async Task<bool> UpdateToDoList([FromBody] UpdateToDoListCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateToDoListCommand
            {
                Id = command.Id,
                Name = command.Name,
                User = command.User
            }, cancellationToken);
        }

        [HttpDelete("{id:long:min(1)}")]
        public async Task<bool> DeleteToDoList([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteToDoListCommand { Id = id }, cancellationToken);
        }
    }
}
