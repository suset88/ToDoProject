using MediatR;
using System.Collections.Generic;

namespace ToDoProject.Application.Queries.ToDoList
{
    public class GetToDoListByUserQuery : IRequest<List<Models.ToDoList>>
    {
        public string User { get; set; }
    }
}
