using MediatR;

namespace ToDoProject.Application.Commands.ToDoListItem
{
    public class CompleteToDoListItemCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
