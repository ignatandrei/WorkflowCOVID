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
    public class AnamnesisController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public AnamnesisController(WorkflowCovidContext context)
        {
            _context = context;
        }

        // GET: api/Anamnesis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anamnesis>>> GetAnamnesis()
        {
            return await _context.Anamnesis.ToListAsync();
        }

        // GET: api/Anamnesis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anamnesis>> GetAnamnesis(long id)
        {
            var anamnesis = await _context.Anamnesis.FindAsync(id);

            if (anamnesis == null)
            {
                return NotFound();
            }

            return anamnesis;
        }

        // PUT: api/Anamnesis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnamnesis(long id, Anamnesis anamnesis)
        {
            if (id != anamnesis.Id)
            {
                return BadRequest();
            }

            _context.Entry(anamnesis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnamnesisExists(id))
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

        // POST: api/Anamnesis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Anamnesis>> PostAnamnesis(Anamnesis anamnesis)
        {
            _context.Anamnesis.Add(anamnesis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnamnesis", new { id = anamnesis.Id }, anamnesis);
        }

        // DELETE: api/Anamnesis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anamnesis>> DeleteAnamnesis(long id)
        {
            var anamnesis = await _context.Anamnesis.FindAsync(id);
            if (anamnesis == null)
            {
                return NotFound();
            }

            _context.Anamnesis.Remove(anamnesis);
            await _context.SaveChangesAsync();

            return anamnesis;
        }

        private bool AnamnesisExists(long id)
        {
            return _context.Anamnesis.Any(e => e.Id == id);
        }
    }
}
