using MediatR;

namespace ToDoProject.Application.Commands.ToDoList
{
    public class DeleteToDoListCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
