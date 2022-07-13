using MediatR;

namespace ToDoProject.Application.Commands.ToDoListItem
{
    public class DeleteToDoListItemCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
