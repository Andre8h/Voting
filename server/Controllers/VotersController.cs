using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly VotingDbcontext _context;

        public VotersController(VotingDbcontext context)
        {
            _context = context;
        }

        // GET: api/Voters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voters>>> GetVoters()
        {
            return await _context.Voters.ToListAsync();
        }

        // GET: api/Voters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voters>> GetVoters(int id)
        {
            var voters = await _context.Voters.FindAsync(id);

            if (voters == null)
            {
                return NotFound();
            }

            return voters;
        }

        // PUT: api/Voters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoters(int id, Voters voters)
        {
            if (id != voters.ID)
            {
                return BadRequest();
            }

            _context.Entry(voters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotersExists(id))
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

        // POST: api/Voters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voters>> PostVoters(Voters voters)
        {
            _context.Voters.Add(voters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoters", new { id = voters.ID }, voters);
        }

        // DELETE: api/Voters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoters(int id)
        {
            var voters = await _context.Voters.FindAsync(id);
            if (voters == null)
            {
                return NotFound();
            }

            _context.Voters.Remove(voters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotersExists(int id)
        {
            return _context.Voters.Any(e => e.ID == id);
        }
    }
}
