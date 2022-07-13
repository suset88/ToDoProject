using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Application.Models;
using ToDoProject.Application.Queries.ToDoList;
using ToDoProject.ViewModels;

namespace ToDoProject.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IMediator _mediator;

        public ToDoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ToDoListController
        public async Task<IActionResult> Index(string userFilter)
        {
            var users = new List<string>();//await _mediator.Send(new GetToDoListUsersQuery());

            var todos = string.IsNullOrWhiteSpace(userFilter)
                ? await _mediator.Send(new GetToDoListsQuery())
                : await _mediator.Send(new GetToDoListByUserQuery { User = userFilter });

            return View(new ToDoListViewModel { Users = new SelectList(users), ToDoLists = todos });
        }

        // GET: ToDoListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,User")] ToDoList todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _mediator.Send(new CreateToDoListCommand { Name = todo.Name, User = todo.User });
                    return RedirectToAction(nameof(Index));
                }

                return View(todo);
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
