using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoListItem
{
    public class CreateToDoListItemCommandHandler : IRequestHandler<CreateToDoListItemCommand, long>
    {
        private readonly ToDoListItemRepository _repository;
        private readonly ToDoListRepository _listRepository;
        private readonly IMapper _mapper;

        public CreateToDoListItemCommandHandler(ToDoListItemRepository repository, ToDoListRepository listRepository, IMapper mapper)
        {
            _repository = repository;
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var listExist = await _listRepository.ExistEntityByIdAsync(request.ToDoListEntityId);
            if (!listExist) return -1;

            var alreadyExist = (await _repository.GetAllAsync()).Any(s => s.ToDoListEntityId == request.ToDoListEntityId && s.Name == request.Name);
            if (alreadyExist) return -1;

            var entity = _mapper.Map<ToDoListItemEntity>(request);

            return await _repository.AddEntityAsync(entity);
        }
    }
}
