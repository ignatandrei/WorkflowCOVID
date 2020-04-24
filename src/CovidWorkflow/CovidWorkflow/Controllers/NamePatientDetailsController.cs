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
    public class NamePatientDetailsController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public NamePatientDetailsController(WorkflowCovidContext context)
        {
            _context = context;
        }

        // GET: api/NamePatientDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NamePatientDetails>>> GetNamePatientDetails()
        {
            return await _context.NamePatientDetails.ToListAsync();
        }

        // GET: api/NamePatientDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NamePatientDetails>> GetNamePatientDetails(int id)
        {
            var namePatientDetails = await _context.NamePatientDetails.FindAsync(id);

            if (namePatientDetails == null)
            {
                return NotFound();
            }

            return namePatientDetails;
        }

        // PUT: api/NamePatientDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNamePatientDetails(int id, NamePatientDetails namePatientDetails)
        {
            if (id != namePatientDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(namePatientDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NamePatientDetailsExists(id))
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

        // POST: api/NamePatientDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NamePatientDetails>> PostNamePatientDetails(NamePatientDetails namePatientDetails)
        {
            _context.NamePatientDetails.Add(namePatientDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNamePatientDetails", new { id = namePatientDetails.Id }, namePatientDetails);
        }

        // DELETE: api/NamePatientDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NamePatientDetails>> DeleteNamePatientDetails(int id)
        {
            var namePatientDetails = await _context.NamePatientDetails.FindAsync(id);
            if (namePatientDetails == null)
            {
                return NotFound();
            }

            _context.NamePatientDetails.Remove(namePatientDetails);
            await _context.SaveChangesAsync();

            return namePatientDetails;
        }

        private bool NamePatientDetailsExists(int id)
        {
            return _context.NamePatientDetails.Any(e => e.Id == id);
        }
    }
}
