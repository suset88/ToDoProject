using MediatR;

namespace ToDoProject.Application.Commands.ToDoList
{
    public record CreateToDoListCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string User { get; set; }
    }
}
