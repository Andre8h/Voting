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
    public class CandidateVoteCountsController : ControllerBase
    {
        private readonly VotingDbcontext _context;

        public CandidateVoteCountsController(VotingDbcontext context)
        {
            _context = context;
        }

        // GET: api/CandidateVoteCounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateVoteCounts>>> GetCandidateVoteCounts()
        {
            return await _context.CandidateVoteCounts.ToListAsync();
        }

        // GET: api/CandidateVoteCounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateVoteCounts>> GetCandidateVoteCounts(int id)
        {
            var candidateVoteCounts = await _context.CandidateVoteCounts.FindAsync(id);

            if (candidateVoteCounts == null)
            {
                return NotFound();
            }

            return candidateVoteCounts;
        }

        // PUT: api/CandidateVoteCounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateVoteCounts(int id, CandidateVoteCounts candidateVoteCounts)
        {
            if (id != candidateVoteCounts.candidate_id)
            {
                return BadRequest();
            }

            _context.Entry(candidateVoteCounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateVoteCountsExists(id))
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

        // POST: api/CandidateVoteCounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandidateVoteCounts>> PostCandidateVoteCounts(CandidateVoteCounts candidateVoteCounts)
        {
            _context.CandidateVoteCounts.Add(candidateVoteCounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateVoteCounts", new { id = candidateVoteCounts.candidate_id }, candidateVoteCounts);
        }

        // DELETE: api/CandidateVoteCounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateVoteCounts(int id)
        {
            var candidateVoteCounts = await _context.CandidateVoteCounts.FindAsync(id);
            if (candidateVoteCounts == null)
            {
                return NotFound();
            }

            _context.CandidateVoteCounts.Remove(candidateVoteCounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateVoteCountsExists(int id)
        {
            return _context.CandidateVoteCounts.Any(e => e.candidate_id == id);
        }
    }
}
