using ToDoProject.Domain.Enums;

namespace ToDoProject.Application.Models
{
    public class ToDoListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
    }
}
