using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidDB.ModelsSqlServer;

namespace CovidWorkflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalTestsController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public MedicalTestsController(WorkflowCovidContext context)
        {
            _context = context;
        }

        // GET: api/MedicalTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalTests>>> GetMedicalTests()
        {
            return await _context.MedicalTests.ToListAsync();
        }

        // GET: api/MedicalTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalTests>> GetMedicalTests(long id)
        {
            var medicalTests = await _context.MedicalTests.FindAsync(id);

            if (medicalTests == null)
            {
                return NotFound();
            }

            return medicalTests;
        }

        // PUT: api/MedicalTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalTests(long id, MedicalTests medicalTests)
        {
            if (id != medicalTests.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalTests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalTestsExists(id))
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

        // POST: api/MedicalTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicalTests>> PostMedicalTests(MedicalTests medicalTests)
        {
            _context.MedicalTests.Add(medicalTests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalTests", new { id = medicalTests.Id }, medicalTests);
        }

        // DELETE: api/MedicalTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalTests>> DeleteMedicalTests(long id)
        {
            var medicalTests = await _context.MedicalTests.FindAsync(id);
            if (medicalTests == null)
            {
                return NotFound();
            }

            _context.MedicalTests.Remove(medicalTests);
            await _context.SaveChangesAsync();

            return medicalTests;
        }

        private bool MedicalTestsExists(long id)
        {
            return _context.MedicalTests.Any(e => e.Id == id);
        }
    }
}
