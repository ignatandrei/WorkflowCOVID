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
    public class AnamnesisPatientsController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public AnamnesisPatientsController(WorkflowCovidContext context)
        {
            _context = context;
        }

        // GET: api/AnamnesisPatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnamnesisPatient>>> GetAnamnesisPatient()
        {
            return await _context.AnamnesisPatient.ToListAsync();
        }

        // GET: api/AnamnesisPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnamnesisPatient>> GetAnamnesisPatient(long id)
        {
            var anamnesisPatient = await _context.AnamnesisPatient.FindAsync(id);

            if (anamnesisPatient == null)
            {
                return NotFound();
            }

            return anamnesisPatient;
        }

        // PUT: api/AnamnesisPatients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnamnesisPatient(long id, AnamnesisPatient anamnesisPatient)
        {
            if (id != anamnesisPatient.Idpatient)
            {
                return BadRequest();
            }

            _context.Entry(anamnesisPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnamnesisPatientExists(id))
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

        // POST: api/AnamnesisPatients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnamnesisPatient>> PostAnamnesisPatient(AnamnesisPatient anamnesisPatient)
        {
            _context.AnamnesisPatient.Add(anamnesisPatient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnamnesisPatientExists(anamnesisPatient.Idpatient))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnamnesisPatient", new { id = anamnesisPatient.Idpatient }, anamnesisPatient);
        }

        // DELETE: api/AnamnesisPatients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnamnesisPatient>> DeleteAnamnesisPatient(long id)
        {
            var anamnesisPatient = await _context.AnamnesisPatient.FindAsync(id);
            if (anamnesisPatient == null)
            {
                return NotFound();
            }

            _context.AnamnesisPatient.Remove(anamnesisPatient);
            await _context.SaveChangesAsync();

            return anamnesisPatient;
        }

        private bool AnamnesisPatientExists(long id)
        {
            return _context.AnamnesisPatient.Any(e => e.Idpatient == id);
        }
    }
}
