using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Repositories;

namespace ToDoProject.Infrastructure.CommandsHandlers.ToDoList
{
    public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommand, long>
    {
        private readonly ToDoListRepository _repository;
        private readonly IMapper _mapper;

        public CreateToDoListCommandHandler(ToDoListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var alreadyExist = (await _repository.GetAllAsync()).Any(s => s.Name == request.Name && s.User == request.User);
            if (alreadyExist) return -1;

            var entity = _mapper.Map<ToDoListEntity>(request);

            return await _repository.AddEntityAsync(entity);
        }
    }
}
