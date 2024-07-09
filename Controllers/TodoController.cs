using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using System.Linq;
using System;

namespace Todo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodosController : ControllerBase
  {
    private readonly TodoContext _context;

    public TodosController(TodoContext context)
    {
      _context = context;
    }

    // GET: api/todos
    [HttpGet]
    public IActionResult GetAll()
    {
      var todos = _context.TodoItems.ToList();
      return Ok(todos);
    }

    // GET: api/todos/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var todo = _context.TodoItems.Find(id);
      if (todo == null)
      {
        return NotFound();
      }
      return Ok(todo);
    }

    // POST: api/todos
    [HttpPost]
    [HttpPost]
public IActionResult Add([FromBody] TodoItem todo)
{
    if (ModelState.IsValid)
    {
        // Log a descrição recebida
        Console.WriteLine($"Recebido: {todo.Description}");

        _context.TodoItems.Add(todo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }
    return BadRequest(ModelState);
}


    // PUT: api/todos/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] TodoItem todo)
    {
      if (id != todo.Id)
      {
        return BadRequest();
      }

      _context.TodoItems.Update(todo);
      _context.SaveChanges();
      return NoContent();
    }

    // DELETE: api/todos/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var todo = _context.TodoItems.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      _context.TodoItems.Remove(todo);
      _context.SaveChanges();
      return NoContent();
    }
  }
}
