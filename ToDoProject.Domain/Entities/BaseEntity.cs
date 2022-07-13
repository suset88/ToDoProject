using System.ComponentModel.DataAnnotations;

namespace ToDoProject.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
