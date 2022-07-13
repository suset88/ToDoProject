using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ToDoProject.Application.Models;

namespace ToDoProject.ViewModels
{
    public class ToDoListViewModel
    {
        public List<ToDoList> ToDoLists { get; set; }
        public SelectList Users { get; set; }
        public string UserFilter { get; set; }
    }
}
