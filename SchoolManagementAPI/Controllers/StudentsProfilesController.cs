using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfilesController : ControllerBase
    {
        private readonly SchoolManagementContext _context;

        public StudentProfilesController(SchoolManagementContext context)
        {
            _context = context;
        }

        // GET: api/StudentProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentProfile>>> GetStudentProfiles()
        {
            return await _context.studentProfiles.ToListAsync();
        }

        // GET: api/StudentProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentProfile>> GetStudentProfile(int id)
        {
            var studentProfile = await _context.studentProfiles.FindAsync(id);

            if (studentProfile == null)
            {
                return NotFound();
            }

            return studentProfile;
        }

        // POST: api/StudentProfiles
        [HttpPost]
        public async Task<ActionResult<StudentProfile>> PostStudentProfile(StudentProfile studentProfile)
        {
            _context.studentProfiles.Add(studentProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentProfile), new { id = studentProfile.StudentProfileId }, studentProfile);
        }

        // PUT: api/StudentProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentProfile(int id, StudentProfile studentProfile)
        {
            if (id != studentProfile.StudentProfileId)
            {
                return BadRequest();
            }

            _context.Entry(studentProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentProfileExists(id))
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

        // PATCH: api/StudentProfiles/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudentProfile(int id, [FromBody] JsonPatchDocument<StudentProfile> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Patch document is null.");
            }

            var studentProfile = await _context.studentProfiles.FindAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(studentProfile, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentProfileExists(id))
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

        // DELETE: api/StudentProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentProfile(int id)
        {
            var studentProfile = await _context.studentProfiles.FindAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            _context.studentProfiles.Remove(studentProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentProfileExists(int id)
        {
            return _context.studentProfiles.Any(e => e.StudentProfileId == id);
        }
    }
}
