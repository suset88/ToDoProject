using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoList
{
    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand, bool>
    {
        private readonly ToDoListRepository _repository;

        public DeleteToDoListCommandHandler(ToDoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repository.ExistEntityByIdAsync(request.Id);
            if (!exist) return false;

            return await _repository.DeleteEntityByIdAsync(request.Id);
        }
    }
}
