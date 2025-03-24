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
    public class CandidatesController : ControllerBase
    {
        private readonly VotingDbcontext _context;

        public CandidatesController(VotingDbcontext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidates>> GetCandidates(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);

            if (candidates == null)
            {
                return NotFound();
            }

            return candidates;
        }

        // PUT: api/Candidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidates(int id, Candidates candidates)
        {
            if (id != candidates.Candidate_Id)
            {
                return BadRequest();
            }

            _context.Entry(candidates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatesExists(id))
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

        // POST: api/Candidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidates>> PostCandidates(Candidates candidates)
        {
            _context.Candidates.Add(candidates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidates", new { id = candidates.Candidate_Id }, candidates);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidates(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidates);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatesExists(int id)
        {
            return _context.Candidates.Any(e => e.Candidate_Id == id);
        }
    }
}
