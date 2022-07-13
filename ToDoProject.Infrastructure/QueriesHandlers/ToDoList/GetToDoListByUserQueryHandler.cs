using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Queries.ToDoList;
using ToDoProject.Infrastructure.Repositories;
using Models = ToDoProject.Application.Models;

namespace ToDoProject.Infrastructure.QueriesHandlers.ToDoList
{
    public class GetToDoListByUserQueryHandler : IRequestHandler<GetToDoListByUserQuery, List<Models.ToDoList>>
    {
        private readonly ToDoListRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoListByUserQueryHandler(ToDoListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Models.ToDoList>> Handle(GetToDoListByUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetEntitiesByUserAsync(request.User);
            if (!entities.Any()) return null;

            return _mapper.Map<List<Models.ToDoList>>(entities);
        }
    }
}
