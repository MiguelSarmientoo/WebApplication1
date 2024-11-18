using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.Where(g => !g.IsDeleted).ToListAsync();
        }

        // GET: api/grades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null || grade.IsDeleted)
            {
                return NotFound();
            }

            return grade;
        }

        // POST: api/grades
        [HttpPost]
        public async Task<ActionResult<Grade>> CreateGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = grade.IdGrade }, grade);
        }

        // PUT: api/grades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, Grade grade)
        {
            if (id != grade.IdGrade)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/grades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null || grade.IsDeleted)
            {
                return NotFound();
            }

            // Eliminación lógica
            grade.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Otro metodo auxiliar para verificar si una calificacioon existe
        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.IdGrade == id);
        }
    }
}
