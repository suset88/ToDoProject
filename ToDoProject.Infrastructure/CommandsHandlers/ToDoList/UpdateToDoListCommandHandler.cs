using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoList
{
    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand, bool>
    {
        private readonly ToDoListRepository _repository;
        private readonly IMapper _mapper;

        public UpdateToDoListCommandHandler(ToDoListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repository.ExistEntityByIdAsync(request.Id);
            if (!exist) return false;

            var updatedEntity = _mapper.Map<ToDoListEntity>(request);

            return await _repository.UpdateEntityAsync(updatedEntity);
        }
    }
}
