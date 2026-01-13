using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // Make sure matches your Data folder
using StudentRegistration.Models; // Must match Models folder
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
           


            return CreatedAtAction(nameof(GetAll), new { id =Students.Id }, Students);
        }
    }
}
