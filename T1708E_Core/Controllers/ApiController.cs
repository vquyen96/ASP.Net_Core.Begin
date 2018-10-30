using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T1708E_Core.Models;

namespace T1708E_Core.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly StudentContext _context;

        public ApiController(StudentContext context)
        {
            _context = context;

            if (_context != null && !_context.Students.Any())
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Students.Add(new Student() { Name = "Student 1", RollNumber = "RollNumber 1"});
                _context.SaveChanges();
            }
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return _context.Students.ToList();
        }


        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Student> GetById(long id)
        {
            var item = _context.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = student.Id }, student);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, Student item)
        {
            var todo = _context.Students.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Name = item.Name;
            todo.RollNumber = item.RollNumber;
            

            _context.Students.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Students.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Students.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}