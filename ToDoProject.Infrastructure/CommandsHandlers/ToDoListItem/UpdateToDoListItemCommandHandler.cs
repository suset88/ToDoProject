using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoListItem
{
    public class UpdateToDoListItemCommandHandler : IRequestHandler<UpdateToDoListItemCommand, bool>
    {
        private readonly ToDoListItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateToDoListItemCommandHandler(ToDoListItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repository.ExistEntityByIdAsync(request.Id);
            if (!exist) return false;

            var updatedEntity = _mapper.Map<ToDoListItemEntity>(request);

            return await _repository.UpdateEntityAsync(updatedEntity);
        }
    }
}
