using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoListItem
{
    public class DeleteToDoListItemCommandHandler : IRequestHandler<DeleteToDoListItemCommand, bool>
    {
        private readonly ToDoListItemRepository _repository;

        public DeleteToDoListItemCommandHandler(ToDoListItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repository.ExistEntityByIdAsync(request.Id);
            if (!exist) return false;

            return await _repository.DeleteEntityByIdAsync(request.Id);
        }
    }
}
