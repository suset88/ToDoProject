using ToDoProject.Domain.Enums;

namespace ToDoProject.Domain.Entities
{
    public class ToDoListItemEntity : BaseEntity
    {
        public string Description { get; set; }
        public ItemStatus Status { get; set; }

        public long ToDoListEntityId { get; set; }
        public ToDoListEntity ToDoListEntity { get; set; }
    }
}
