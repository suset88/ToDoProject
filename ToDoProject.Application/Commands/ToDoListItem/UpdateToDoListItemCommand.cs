using MediatR;
using ToDoProject.Domain.Enums;

namespace ToDoProject.Application.Commands.ToDoListItem
{
    public class UpdateToDoListItemCommand : IRequest<bool>
    {
        public long ToDoListEntityId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
    }
}
