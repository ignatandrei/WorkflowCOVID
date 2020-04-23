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
    public class CovidStatusController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public CovidStatusController(WorkflowCovidContext context)
        {
            _context = context;
        }

        // GET: api/CovidStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidStatus>>> GetCovidStatus()
        {
            return await _context.CovidStatus.ToListAsync();
        }

        // GET: api/CovidStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidStatus>> GetCovidStatus(int id)
        {
            var covidStatus = await _context.CovidStatus.FindAsync(id);

            if (covidStatus == null)
            {
                return NotFound();
            }

            return covidStatus;
        }

        // PUT: api/CovidStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovidStatus(int id, CovidStatus covidStatus)
        {
            if (id != covidStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(covidStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidStatusExists(id))
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

        // POST: api/CovidStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CovidStatus>> PostCovidStatus(CovidStatus covidStatus)
        {
            _context.CovidStatus.Add(covidStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCovidStatus", new { id = covidStatus.Id }, covidStatus);
        }

        // DELETE: api/CovidStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CovidStatus>> DeleteCovidStatus(int id)
        {
            var covidStatus = await _context.CovidStatus.FindAsync(id);
            if (covidStatus == null)
            {
                return NotFound();
            }

            _context.CovidStatus.Remove(covidStatus);
            await _context.SaveChangesAsync();

            return covidStatus;
        }

        private bool CovidStatusExists(int id)
        {
            return _context.CovidStatus.Any(e => e.Id == id);
        }
    }
}
