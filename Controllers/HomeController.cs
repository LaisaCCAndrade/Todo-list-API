using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Models;
using Todo.Models.ViewModels;
using System.Linq;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoContext _context;

        public HomeController(ILogger<HomeController> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var todoListViewModel = new TodoViewModel
            {
                TodoList = _context.TodoItems.ToList(),
                Todo = new TodoItem()
            };
            return View(todoListViewModel);
        }
    }
}
