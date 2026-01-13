using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // Required for async EF Core calls
using StudentRegistration.Data;       // Make sure this matches your Data folder namespace
using StudentRegistration.Models;     // Make sure this matches your Models folder namespace
using StudentRegistrationAPI.Data;
using System.Threading.Tasks;         // Required for async Task

namespace StudentRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor injects the database context
        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Student.ToListAsync();
            return Ok(students);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Student data is required.");

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);
        }
    }
}
