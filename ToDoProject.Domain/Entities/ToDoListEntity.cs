using System.Collections.Generic;

namespace ToDoProject.Domain.Entities
{
    public class ToDoListEntity : BaseEntity
    {
        public string User { get; set; }

        public ICollection<ToDoListItemEntity> ItemsEntities { get; set; }
    }
}
