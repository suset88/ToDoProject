using MediatR;
using System.Collections.Generic;

namespace ToDoProject.Application.Queries.ToDoList
{
    public record GetToDoListsQuery : IRequest<List<Models.ToDoList>> { }
}
