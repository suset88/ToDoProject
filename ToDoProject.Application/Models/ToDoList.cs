using System.Collections.Generic;

namespace ToDoProject.Application.Models
{
    public class ToDoList
    {
        public long Id { get; set; }
        public string Name { get; set; }    
        public string User { get; set; }

        public ICollection<ToDoListItem> Items { get; set; }
    }
}
