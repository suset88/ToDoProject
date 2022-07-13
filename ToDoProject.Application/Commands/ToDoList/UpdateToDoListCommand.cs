using MediatR;

namespace ToDoProject.Application.Commands.ToDoList
{
    public class UpdateToDoListCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
    }
}
