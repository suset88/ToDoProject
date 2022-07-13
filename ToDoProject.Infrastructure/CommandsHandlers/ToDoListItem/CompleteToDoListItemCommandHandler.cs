using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoListItem
{
    public class CompleteToDoListItemCommandHandler : IRequestHandler<CompleteToDoListItemCommand, bool>
    {
        private readonly ToDoListItemRepository _repository;

        public CompleteToDoListItemCommandHandler(ToDoListItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CompleteToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var entity = (await _repository.GetAllAsync()).FirstOrDefault(e=> e.Id == request.Id);
            if (entity == null) return false;

            entity.Status = Domain.Enums.ItemStatus.Completed;

            return await _repository.UpdateEntityAsync(entity);
        }
    }
}
