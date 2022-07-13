using MediatR;
using System.Collections.Generic;

namespace ToDoProject.Application.Queries.ToDoListItem
{
    public record GetToDoListItemsQuery : IRequest<List<Models.ToDoListItem>> { }
}
