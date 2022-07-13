using MediatR;
using ToDoProject.Domain.Enums;

namespace ToDoProject.Application.Commands.ToDoListItem
{
    public class CreateToDoListItemCommand : IRequest<long>
    {
        public long ToDoListEntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
    }
}
