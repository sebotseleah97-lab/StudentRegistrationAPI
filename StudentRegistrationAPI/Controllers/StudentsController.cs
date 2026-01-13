using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;
using StudentRegistrationAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        // POST new student
        [HttpPost]
        public async Task<ActionResult<Student>> Add([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Student data is required.");

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);
        }
    }
}
