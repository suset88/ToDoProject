using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoProject.Application.Queries.ToDoListItem;
using ToDoProject.Infrastructure.Repositories;
using Models = ToDoProject.Application.Models;

namespace ToDoProject.Infrastructure.QueriesHandlers.ToDoListItem
{
    public class GetToDoListItemsQueryHandler : IRequestHandler<GetToDoListItemsQuery, List<Models.ToDoListItem>>
    {
        private readonly ToDoListItemRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoListItemsQueryHandler(ToDoListItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Models.ToDoListItem>> Handle(GetToDoListItemsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            if (!entities.Any()) return new List<Models.ToDoListItem>();

            return _mapper.Map<List<Models.ToDoListItem>>(entities);
        }
    }
}
